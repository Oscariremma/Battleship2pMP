using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibOscar
{
    public static class Methods
    {
        public static T CreateJaggedArray<T>(params int[] lengths)
        {
            return (T)InitializeJaggedArray(typeof(T).GetElementType(), 0, lengths);
        }

        private static object InitializeJaggedArray(Type type, int index, int[] lengths)
        {
            Array array = Array.CreateInstance(type, lengths[index]);
            Type elementType = type.GetElementType();

            if (elementType != null)
            {
                for (int i = 0; i < lengths[index]; i++)
                {
                    array.SetValue(
                        InitializeJaggedArray(elementType, index + 1, lengths), i);
                }
            }

            return array;
        }

        public static byte[] GetBinaryArray<T>(T objectToConvert, bool commpress = false)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (commpress == true)
            {
                using (MemoryStream compMS = new MemoryStream())
                {
                    using (DeflateStream deflateStream = new DeflateStream(compMS, CompressionMode.Compress, true))
                    {
                        formatter.Serialize(deflateStream, objectToConvert);
                    }
                    return compMS.ToArray();
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, objectToConvert);

                    return ms.ToArray();
                }
            }
        }

        public static T GetObjectFromBinaryArray<T>(byte[] Bytes, bool Decommpress = false)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (Decommpress == true)
            {
                using (DeflateStream deflateStream = new DeflateStream(new MemoryStream(Bytes), CompressionMode.Decompress))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        return (T)formatter.Deserialize(deflateStream);
                    }
                }
            }

            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                return (T)formatter.Deserialize(ms);
            }
        }

        public static void DrawLinesFromArray(System.Drawing.Graphics graphics, System.Drawing.Pen pen, Line[] lines)
        {
            foreach (Line line in lines)
            {
                graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
            }
        }
    }

    public static class ExecutionTimer
    {
        private static List<System.Timers.Timer> Timers = new List<System.Timers.Timer>();

        public static void ExecuteAfterDelay(System.Timers.ElapsedEventHandler DelayedMethod, int Delay)
        {
            System.Timers.Timer Timer = new System.Timers.Timer();

            Timer.Interval = Delay;
            Timer.AutoReset = false;
            Timer.Elapsed += DelayedMethod;
            Timer.Elapsed += (sender, e) => RemoveElapsedTimer(sender, e, Timer);

            Timers.Add(Timer);

            Timer.Start();
        }

        public static void ExecuteAfterDelay(System.Timers.ElapsedEventHandler DelayedMethod, int Delay, System.ComponentModel.ISynchronizeInvoke SynchronizingObject)
        {
            System.Timers.Timer Timer = new System.Timers.Timer();

            Timer.Interval = Delay;
            Timer.AutoReset = false;
            Timer.SynchronizingObject = SynchronizingObject;
            Timer.Elapsed += DelayedMethod;
            Timer.Elapsed += (sender, e) => RemoveElapsedTimer(sender, e, Timer);

            Timers.Add(Timer);

            Timer.Start();
        }

        private static void RemoveElapsedTimer(object sender, System.Timers.ElapsedEventArgs e, System.Timers.Timer timerToDispose)
        {
            timerToDispose.Stop();
            Timers.Remove(timerToDispose);
            timerToDispose.Dispose();
        }
    }

    public struct Line
    {
        public Line(System.Drawing.Point Start, System.Drawing.Point End)
        {
            StartPoint = Start;
            EndPoint = End;
        }

        public System.Drawing.Point StartPoint;
        public System.Drawing.Point EndPoint;
    }

    public class Ref<T> where T : struct
    {
        public T Value { get; set; }
    }

    public static class Extensions
    {
        public static T Next<T>(this T srcEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(srcEnum.GetType());
            int j = Array.IndexOf<T>(Arr, srcEnum) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static T Previous<T>(this T srcEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(srcEnum.GetType());
            int j = Array.IndexOf<T>(Arr, srcEnum) - 1;
            return (j == -1) ? Arr[Arr.Length - 1] : Arr[j];
        }
    }
}