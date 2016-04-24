﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GoldenEye.Shared.Core.Objects.Dates
{
    public class DateRange : IEnumerable<DateTime>, IDateRange
    {
        /// <summary>
        /// Field representing starting day of range.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Field representing ending day of range.
        /// </summary>
        public DateTime EndDate { get; set; }

        DateTime? IDateRange.StartDate
        {
            get { return StartDate; }
        }

        DateTime? IDateRange.EndDate
        {
            get { return EndDate; }
        }

        /// <summary>
        /// Returns all dates in the range
        /// </summary>
        public IEnumerable<DateTime> Dates
        {
            get
            {
                var dates = new List<DateTime>();

                foreach (var date in this)
                {
                    dates.Add(date);
                }

                return dates;
            }
        }

        /// <summary>
        /// Length of the range in days.
        /// Starting and ending day are taken into account.
        /// </summary>
        public int Length
        {
            get
            {
                return Convert.ToInt32((EndDate - StartDate).TotalDays) + 1;
            }
        }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public DateRange()
        {
        }

        /// <summary>
        /// Basic constructor, that creates date range from two dates
        /// </summary>
        /// <param name="start">Starting day of range</param>
        /// <param name="end">Ending day of range</param>
        public DateRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException("Start date cannot be greater than end date");

            StartDate = start.Date;
            EndDate = end.Date;
        }

        /// <summary>
        /// Checks, whether chosen date falls in range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="date">Date to be checked</param>
        /// <returns></returns>
        public bool Contains(DateTime date)
        {
            date = date.Date;

            return date >= this.StartDate && date <= this.EndDate;
        }

        /// <summary>
        /// Creates a date range from two dates.
        /// </summary>
        public static DateRange Create(DateTime start, DateTime end)
        {
            return new DateRange(start, end);
        }

        // IEnumerable implementation
        public IEnumerator<DateTime> GetEnumerator()
        {
            for (var date = StartDate; date <= EndDate; date = date.AddDays(1).Date)
            {
                yield return date.Date;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var rangeObj = obj as DateRange;
            if (rangeObj == null)
            {
                return false;
            }

            return this.StartDate == rangeObj.StartDate && this.EndDate == rangeObj.EndDate;
        }

        public bool Equals(DateRange obj)
        {
            return this == obj;
        }

        public static bool operator ==(DateRange left, DateRange right)
        {
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left.StartDate == right.StartDate && left.EndDate == right.EndDate;
        }

        public static bool operator !=(DateRange left, DateRange right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.StartDate.GetHashCode() ^ this.EndDate.Ticks.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Date range: {0:d} - {1:d}", this.StartDate, this.EndDate);
        }
    }
}