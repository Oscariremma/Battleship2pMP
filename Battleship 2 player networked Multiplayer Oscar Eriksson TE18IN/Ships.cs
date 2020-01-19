﻿using ProtoBuf;
using System;
using System.Drawing;

namespace Battleship2pMP.Ships
{
    public class Ship
    {
        public int Length;

        public Image ShipSprite;

        public ShipEnum ShipEnum;

        public static CarrierType Carrier = new CarrierType();
        public static BattleshipType Battleship = new BattleshipType();
        public static CruiserType Cruiser = new CruiserType();
        public static DestroyerType Destroyer = new DestroyerType();
        public static SubMarineType SubMarine = new SubMarineType();

        //Load Ship sprites in to memory
        public static void LoadShips()
        {
            Carrier.ShipSprite = Properties.Resources.ShipCarrierHullComplete;
            Battleship.ShipSprite = Properties.Resources.ShipBattleshipComplete;
            Cruiser.ShipSprite = Properties.Resources.ShipCruiserComplete;
            Destroyer.ShipSprite = Properties.Resources.ShipDestroyerComplete;
            SubMarine.ShipSprite = Properties.Resources.ShipSubMarineComplete;
        }

        public static Ship ShipFromShipEnum(ShipEnum shipEnum)
        {
            switch (shipEnum)
            {
                case ShipEnum.Battleship:
                    return Battleship;

                case ShipEnum.Carrier:
                    return Carrier; ;
                case ShipEnum.Cruiser:
                    return Cruiser;

                case ShipEnum.Destroyer:
                    return Destroyer;

                case ShipEnum.SubMarine:
                    return SubMarine;
            }

            throw new Exception("Impossible Exception");
        }
    }

    #region Ship Declarations

    public class CarrierType : Ship
    {
        public CarrierType()
        {
            Length = 5;
            ShipEnum = ShipEnum.Carrier;
        }
    }

    public class BattleshipType : Ship
    {
        public BattleshipType()
        {
            Length = 4;
            ShipEnum = ShipEnum.Battleship;
        }
    }

    public class CruiserType : Ship
    {
        public CruiserType()
        {
            Length = 3;
            ShipEnum = ShipEnum.Cruiser;
        }
    }

    public class DestroyerType : Ship
    {
        public DestroyerType()
        {
            Length = 2;
            ShipEnum = ShipEnum.Destroyer;
        }
    }

    public class SubMarineType : Ship
    {
        public SubMarineType()
        {
            Length = 1;
            ShipEnum = ShipEnum.SubMarine;
        }
    }

    public enum ShipEnum
    {
        Carrier, Battleship, Cruiser, Destroyer, SubMarine
    }

    #endregion Ship Declarations

    [ProtoContract]
    public struct ShipsLeft
    {
        [ProtoMember(1)]
        public int Carriers;

        [ProtoMember(2)]
        public int Battleships;

        [ProtoMember(3)]
        public int Cruisers;

        [ProtoMember(4)]
        public int Destroyers;

        [ProtoMember(5)]
        public int Submarines;

        public int Total
        {
            get { return Carriers + Battleships + Cruisers + Destroyers + Submarines; }
        }

        public ShipsLeft(int Carrier, int Battleship, int Cruiser, int Destroyer, int Submarine)
        {
            Carriers = Carrier;
            Battleships = Battleship;
            Cruisers = Cruiser;
            Destroyers = Destroyer;
            Submarines = Submarine;
        }
    }
}