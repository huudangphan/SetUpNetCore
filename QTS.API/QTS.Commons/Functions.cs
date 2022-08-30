using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QTS.Commons
{
    public class Functions
    {
        public static DateTime ParseDateTimes(object obj, string format = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(format))
                {
                    return DateTime.ParseExact(obj.ToString(), format, CultureInfo.InvariantCulture);

                }
                DateTime result;
                if (obj == null) return DateTime.Now.Date;
                //if (obj != null && DateTime.Parse(obj.ToString()).Year == 1899) return null;
                //if (obj != null && DateTime.Parse(obj.ToString()).Year == 1900) return null;
                if (DateTime.TryParse(obj.ToString(), out result))
                    return result;
                return DateTime.Now.Date;
            }
            catch (Exception)
            {
                return DateTime.Now.Date;
            }
        }

        /// <summary>
        /// hàm parse object to string
        /// exception return ""
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            try
            {
                if (obj == null) return string.Empty;
                return obj.ToString().Trim();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// parse object to int
        /// exception return 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseInt(object obj)
        {
            try
            {
                int result;
                if (obj == null) return 0;
                if (int.TryParse(obj.ToString(), out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static double ParseDouble(object obj)
        {
            try
            {
                double result;
                if (obj == null) return 0;
                if (double.TryParse(obj.ToString(), out result))
                {
                    if (!Double.IsInfinity(result) && !Double.IsNaN(result))
                    {
                        return result;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static double ParseDouble(object obj, NumberFormatInfo provider)
        {
            try
            {
                double result;
                if (obj == null) return 0;
                if (double.TryParse(obj.ToString(), NumberStyles.Any, provider, out result))
                    if (!Double.IsInfinity(result) && !Double.IsNaN(result))
                    {
                        return result;
                    }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static float ParseFloat(object obj)
        {
            try
            {
                float result;
                if (obj == null) return 0;
                if (float.TryParse(obj.ToString(), out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static decimal ParseDecimal(object obj)
        {
            try
            {
                decimal result;
                if (obj == null) return 0;
                var value = obj.ToString();
                if (decimal.TryParse(value, out result))
                    return result;
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm parrse object to datetime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? ParseDateTime(object obj, string format = "")
        {
            try
            {
                if (obj == null) return null;
                if (!string.IsNullOrEmpty(format))
                {
                    return DateTime.ParseExact(obj.ToString(), format, CultureInfo.InvariantCulture);
                }
                DateTime result;
                //if (obj != null && DateTime.Parse(obj.ToString()).Year == 1899) return null;
                //if (obj != null && DateTime.Parse(obj.ToString()).Year == 1900) return null;
                if (DateTime.TryParse(obj.ToString(), out result))
                    return result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
