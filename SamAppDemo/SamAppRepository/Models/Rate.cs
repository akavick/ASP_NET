using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SamAppRepository.Models
{
    public class Rate
    {
        public static IReadOnlyDictionary<RateValueType, decimal> RateTypeToValue { get; } = new ReadOnlyDictionary<RateValueType, decimal>(new Dictionary<RateValueType, decimal>
        {
            { RateValueType.Unset, 0.0m },
            { RateValueType.Quarter, 0.25m },
            { RateValueType.Half, 0.5m },
            { RateValueType.HalfAndQuarter, 0.75m },
            { RateValueType.Single, 1.0m },
            { RateValueType.SingleAndQuarter, 1.25m },
            { RateValueType.SingleAndHalf, 1.5m },
            { RateValueType.SingleAndHalfAndQuarter, 1.75m },
            { RateValueType.Double, 2.0m },
        });

        public static IReadOnlyDictionary<decimal, RateValueType> ValueToRateType { get; } = new ReadOnlyDictionary<decimal, RateValueType>(new Dictionary<decimal, RateValueType>
        {
            { 0.0m, RateValueType.Unset },
            { 0.25m, RateValueType.Quarter },
            { 0.5m, RateValueType.Half },
            { 0.75m, RateValueType.HalfAndQuarter },
            { 1.0m, RateValueType.Single },
            { 1.25m, RateValueType.SingleAndQuarter },
            { 1.5m, RateValueType.SingleAndHalf },
            { 1.75m, RateValueType.SingleAndHalfAndQuarter },
            { 2.0m, RateValueType.Double },
        });

        private decimal _value;
        private RateValueType _type = RateValueType.Unset;

        public RateValueType Type
        {
            get => _type;
            set
            {
                _value = RateTypeToValue[value];
                _type = value;
            }
        }

        public decimal Value
        {
            get => _value;
            set
            {
                _type = ValueToRateType[value];
                _value = value;
            }
        }

        public string Name => ToString();

        public static IReadOnlyCollection<Rate> Values { get; } = new List<Rate>
        {
            new Rate { Type = RateValueType.Unset },
            new Rate { Type = RateValueType.Quarter },
            new Rate { Type = RateValueType.Half },
            new Rate { Type = RateValueType.HalfAndQuarter },
            new Rate { Type = RateValueType.Single },
            new Rate { Type = RateValueType.SingleAndQuarter },
            new Rate { Type = RateValueType.SingleAndHalf },
            new Rate { Type = RateValueType.SingleAndHalfAndQuarter },
            new Rate { Type = RateValueType.Double },
        }.AsReadOnly();

        public override string ToString()
        {
            switch (Type)
            {
                case RateValueType.Unset:
                {
                    return "0";
                }
                case RateValueType.Quarter:
                {
                    return "0.25";
                }
                case RateValueType.Half:
                {
                    return "0.5";
                }
                case RateValueType.HalfAndQuarter:
                {
                    return "0.75";
                }
                case RateValueType.Single:
                {
                    return "1";
                }
                case RateValueType.SingleAndQuarter:
                {
                    return "1.25";
                }
                case RateValueType.SingleAndHalf:
                {
                    return "1.5";
                }
                case RateValueType.SingleAndHalfAndQuarter:
                {
                    return "1.75";
                }
                case RateValueType.Double:
                {
                    return "2";
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }
    }
}