using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL;

namespace ASL.Forms
{
  static public class UnitType
  {
    public const string TEMP = "TEMP";
    public const string AREA = "AREA";
    public const string LENGTH = "LENGTH";
    public const string TIME = "TIME";
    public const string VELOCITY = "VELOCITY";
    public const string ACCEL = "ACCEL";
    public const string MASS = "MASS";
    public const string DENSITY = "DENSITY";
    public const string THICKNESS = "THICKNESS";
    public const string MINUTES = "MINUTES";
    public const string AIRFLOWRATE = "AIRFLOWRATE";
    public const string VOLUME = "VOLUME";
    public const string LIQUIDVOLUME = "LIQUIDVOLUME";
    public const string FLOWRATE = "FLOWRATE";
    public const string PRESSURE = "PRESSURE";
    public const string COVERAGE = "COVERAGE";
    public const string CONCENTRATION = "CONCENTRATION";
  }
  
  public static class UnitConvertor
  {

    //      "", "TEMP", "AREA", "LENGTH", "TIME", "VELOCITY", 
    //      "ACCEL", "MASS", "DENSITY", "THICKNESS", "MINUTES", "AIRFLOWRATE"
    //      "VOLUME", "LIQUIDVOLUME", "FLOWRATE", "PRESSURE", "COVERAGE", "CONCENTRATION" 

    static public string MetricUnitTemp = "\u00b0C";
    static public string MetricUnitArea = "m\u00b2";
    static public string MetricUnitLength = "m";
    static public string MetricUnitTime = "sec.";
    static public string MetricUnitVelocity = "m/s";
    static public string MetricUnitAccel = "m/s\u00b2";
    static public string MetricUnitMass = "kg";
    static public string MetricUnitDensity = "kg/m\u00b3";
    static public string MetricUnitVolume = "m\u00b3";
    static public string MetricUnitLiquidVolume = "gal";
    static public string MetricUnitFlowRate = "gpm";
    static public string MetricUnitPressure = "psi";
    static public string MetricUnitCoverage = "gpm/ft\u00b2";
    static public string MetricUnitConcentration = "%";
    static public string MetricUnitThickness = "cm";
    static public string MetricUnitMinutes = "min";
    static public string MetricUnitAirFlowRate = "cfm";

    static public string USUnitTemp = "\u00b0F";
    static public string USUnitArea = "ft\u00b2";
    static public string USUnitLength = "ft";
    static public string USUnitTime = "sec.";
    static public string USUnitVelocity = "ft/s";
    static public string USUnitAccel = "ft/s\u00b2";
    static public string USUnitMass = "lb";
    static public string USUnitDensity = "lb/ft\u00b3";
    static public string USUnitVolume = "ft\u00b3";
    static public string USUnitLiquidVolume = "gal";
    static public string USUnitFlowRate = "gpm";
    static public string USUnitPressure = "psi";
    static public string USUnitCoverage = "gpm/ft\u00b2";
    static public string USUnitConcentration = "%";
    static public string USUnitThickness = "in";
    static public string USUnitMinutes = "min";
    static public string USUnitAirFlowRate = "cfm";

    const double feetPerMeter = 3.281;
    const double poundsPerKg = 2.205;
    const double inchesPerFoot = 12;

    static UnitConvertor()
    {
      Mode = "METRIC";
    }

    static public string Mode { get; set; }

    static public string GetUnit(string unitType)
    {
      switch (Mode)
      {
        case "METRIC":
          {
            switch (unitType)
            {
              case "TEMP":
                return MetricUnitTemp;
              case "AREA":
                return MetricUnitArea;
              case "LENGTH":
                return MetricUnitLength;
              case "THICKNESS":
                return MetricUnitThickness;
              case "TIME":
                return MetricUnitTime;
              case "MINUTES":
                return MetricUnitMinutes;
              case "VELOCITY":
                return MetricUnitVelocity;
              case "ACCEL":
                return MetricUnitAccel;
              case "MASS":
                return MetricUnitMass;
              case "DENSITY":
                return MetricUnitDensity;
              case "VOLUME":
                return MetricUnitVolume;

              case "LIQUIDVOLUME":
                return MetricUnitLiquidVolume;
              case "FLOWRATE":
                return MetricUnitFlowRate;
              case "AIRFLOWRATE":
                return MetricUnitAirFlowRate;
              case "PRESSURE":
                return MetricUnitPressure;
              case "COVERAGE":
                return MetricUnitCoverage;
              case "CONCENTRATION":
                return MetricUnitConcentration;


              default:
                return "?ERROR?";
            }
          }

        case "US":
          {
            switch (unitType)
            {
              case "TEMP":
                return USUnitTemp;
              case "AREA":
                return USUnitArea;
              case "LENGTH":
                return USUnitLength;
              case "THICKNESS":
                return USUnitThickness;
              case "TIME":
                return USUnitTime;
              case "MINUTES":
                return USUnitMinutes;
              case "VELOCITY":
                return USUnitVelocity;
              case "ACCEL":
                return USUnitAccel;
              case "MASS":
                return USUnitMass;
              case "DENSITY":
                return USUnitDensity;
              case "VOLUME":
                return USUnitVolume;

              case "LIQUIDVOLUME":
                return USUnitLiquidVolume;
              case "FLOWRATE":
                return USUnitFlowRate;
              case "AIRFLOWRATE":
                return USUnitAirFlowRate;
              case "PRESSURE":
                return USUnitPressure;
              case "COVERAGE":
                return USUnitCoverage;
              case "CONCENTRATION":
                return USUnitConcentration;

              default:
                return "?ERROR?";
            }
          }

        default:
          return "?ERROR?";
      }
    }

    static public double ConvertDbToValue(string unitType, double dbValue)
    {
      double v = dbValue;
      switch (Mode)
      {
        case "METRIC": break;

        case "US":
          {
            switch (unitType)
            {
              case UnitType.LENGTH:
                v = v = Math.Round(dbValue * feetPerMeter, 3);
                break;
              case UnitType.AREA:
                v = v = Math.Round(dbValue * feetPerMeter * feetPerMeter, 3);
                break;
              case UnitType.MASS:
                v = v = Math.Round(dbValue * poundsPerKg,3);
                break;
              case UnitType.TEMP:
                v = Math.Round(dbValue * 9 / 5 + 32, 3);
                break;
            }
          }
          break;
      }
      return v;
    }

    static public double ConvertValueToDb(string unitType, double userValue)
    {
      double v = userValue;
      switch (Mode)
      {
        case "METRIC": break;

        case "US":
          {
            switch (unitType)
            {
              case UnitType.LENGTH:
                v = userValue / feetPerMeter;
                break;
              case UnitType.AREA:
                v = userValue / feetPerMeter / feetPerMeter;
                break;
              case UnitType.MASS:
                v = userValue / poundsPerKg;
                break;
              case UnitType.TEMP:
                v = (userValue - 32) * 5 / 9;
                break;
            }
          }
          break;
      }
      return v;
    }

    static public bool TryParse(string unitType, string text, out double v)
    {
      v = 0;
      try
      {
        string t = text.Trim().ToUpper();
        switch (Mode)
        {
          case "METRIC":
            return double.TryParse(t, out v);

          case "US":
            {
              double usv;
              switch (unitType)
              {
                case UnitType.LENGTH:
                  {
                    if (!double.TryParse(t, out usv))
                    {
                      if (t.EndsWith("\'"))
                      {
                        int n = t.Length;
                        t = t.Substring(0, n - 1).Trim();
                        if (!double.TryParse(t, out usv)) return false;
                      }
                      else if (t.EndsWith("\""))
                      {
                        int n = t.Length;
                        t = t.Substring(0, n - 1).Trim();
                        if (t.Contains('\''))
                        {
                          string[] tt = t.Split('\'');
                          if (tt.Length != 2) return false;
                          if (!double.TryParse(tt[0].Trim(), out usv)) return false;
                          double usv1;
                          if (!double.TryParse(tt[1].Trim(), out usv1)) return false;
                          usv += usv1 / inchesPerFoot;
                        }
                        else
                        {
                          if (!double.TryParse(t, out usv)) return false;
                          usv = usv / inchesPerFoot;
                        }
                        break; ;
                      }
                    }
                    break;
                  }
                default:
                  {
                    if (!double.TryParse(t, out usv)) return false;
                    break;
                  }
              }
              v = ConvertValueToDb(unitType, usv);
              return true;
            }

          default:
            return false;
        }
      }
      catch
      {
        return false;
      }
    }

    static public double Parse(string unitType, string text)
    {
      double v;
      if (TryParse(unitType, text, out v)) return v;
      throw new AppEx("Invalid value");
    }

    static public string Format(string unitType, string format, double dbValue)
    {
      double v;
      switch (Mode)
      {
        case "METRIC":
          v = dbValue;
          break;

        case "US":
          v = ConvertDbToValue(unitType, dbValue);
          break;

        default:
          return "?ERROR?";
      }
      if (format == string.Empty)
        return v.ToString();
      else
        return v.ToString(format);

    }

  }

}
