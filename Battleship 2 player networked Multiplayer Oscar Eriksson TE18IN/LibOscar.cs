using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibOscar
{
    //This file contains various useful functions


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


        private static readonly byte CompressionFlag = 0xC1;
        private static readonly byte NoCompressionFlag = 0xFC;

        /// <summary>
        /// Returns a <see cref="byte[]"/> from a <see cref="object"/>. Opposite of <see cref="Methods.GetObjectFromBinaryArray{T}(byte[])"/>
        /// </summary>
        /// <param name="objectToConvert">The object to convert to a <see cref="byte[]"/></param>
        /// <param name="Compress">If true the data will be compressed</param>
        public static byte[] GetBinaryArray(object objectToConvert, bool Compress = false)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (Compress == true)
            {
                using (MemoryStream compMS = new MemoryStream())
                {
                    //Write the CompressionFlag to the raw stream
                    compMS.Write(new byte[] { CompressionFlag }, 0, 1);

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
                    //Write the NoCompressionFlag to the raw stream
                    ms.Write(new byte[] { NoCompressionFlag }, 0, 1);

                    formatter.Serialize(ms, objectToConvert);

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="object"/> of type <typeparamref name="T"/> from a <see cref="byte[]"/>. Opposite of <see cref="GetBinaryArray(object, bool)"/> / <seealso cref="Methods.GetBinaryArray(object, bool)"/>
        /// </summary>
        /// <typeparam name="T">The type of the original object passed to <see cref="Methods.GetBinaryArray(object, bool)"/> </typeparam>
        /// <param name="Bytes">The <see cref="byte[]"/> returned from <see cref="Methods.GetBinaryArray(object, bool)"/></param>
        public static T GetObjectFromBinaryArray<T>(byte[] Bytes)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (Bytes[0] == CompressionFlag)
            {
                using (DeflateStream deflateStream = new DeflateStream(new MemoryStream(Bytes.Skip(1).ToArray()), CompressionMode.Decompress))
                {
                    return (T)formatter.Deserialize(deflateStream);
                }
            }else if(Bytes[0] == NoCompressionFlag)
            {
                using (MemoryStream ms = new MemoryStream(Bytes.Skip(1).ToArray()))
                {
                    return (T)formatter.Deserialize(ms);
                }
            }
            else
            {
                throw new InvalidDataException("No valid compression flag found. Data may be corrupt or in the wrong format");
            }

        }

        /// <summary>
        /// Draws all lines in the array using pen on graphics
        /// </summary>
        public static void DrawLinesFromArray(System.Drawing.Graphics graphics, System.Drawing.Pen pen, Line[] lines)
        {
            foreach (Line line in lines)
            {
                graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
            }
        }
    }
    /// <summary>
    /// Class containing functionality for running methods after a delay
    /// </summary>
    public static class ExecutionTimer
    {
        private static List<System.Timers.Timer> Timers = new List<System.Timers.Timer>();
        /// <summary>
        /// Execute DelayedMethod after the specified delay
        /// </summary>
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
        /// <summary>
        /// Execute DelayedMethod after the specified delay with SychronizingObject for compatibility with WinForms
        /// </summary>
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
    /// <summary>
    /// A line with a StartPoint and an EndPoint
    /// </summary>
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

    public static class Extensions
    {
        /// <summary>
        /// Get the next Enum Value from EnumType
        /// </summary>
        public static T Next<T>(this T srcEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(srcEnum.GetType());
            int j = Array.IndexOf<T>(Arr, srcEnum) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        /// <summary>
        /// Get the previous Enum Value from EnumType
        /// </summary>
        public static T Previous<T>(this T srcEnum) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(srcEnum.GetType());
            int j = Array.IndexOf<T>(Arr, srcEnum) - 1;
            return (j == -1) ? Arr[Arr.Length - 1] : Arr[j];
        }
        /// <summary>
        /// Extension version of <see cref="LibOscar.Methods.GetBinaryArray(object, bool)"/>. Will get a <see cref="byte[]"/> from a <see cref="object"/>. Opposite of <see cref="Methods.GetObjectFromBinaryArray{T}(byte[])"/>
        /// </summary>
        /// <param name="sourceObject">The <see cref="object"/> to serialize</param>
        /// <param name="Compress">If true the data will be compressed</param>
        /// <returns></returns>
        public static byte[] GetBinaryArray(this object sourceObject, bool Compress = false)
        {
            return Methods.GetBinaryArray(sourceObject, Compress);
        }

        /// <summary>
        /// Extension version of <see cref="LibOscar.Methods.GetObjectFromBinaryArray{T}(byte[])"/>. Will get back a <see cref="object"/> of type <typeparamref name="T"/> from a <see cref="byte[]"/>. Opposite of <see cref="Methods.GetBinaryArray(object, bool)"/>
        /// </summary>
        /// <typeparam name="T">The type of the original object passed to <see cref="Methods.GetBinaryArray(object, bool)"/> </typeparam>
        /// <param name="ByteArray">The <see cref="byte[]"/> returned from <see cref="Methods.GetBinaryArray(object, bool)"/></param>
        /// <returns></returns>
        public static T GetObjectFromBinaryArray<T>(this byte[] ByteArray)
        {
            return Methods.GetObjectFromBinaryArray<T>(ByteArray);
        }


    }
}