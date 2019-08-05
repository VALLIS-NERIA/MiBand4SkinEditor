﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using MiBand4SkinEditor.Core.Models;
//
//    var skinManifestJson = SkinManifestJson.FromJson(jsonString);

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MiBand4SkinEditor.Core.Models.Json {
    public partial class SkinManifestJson {
        [JsonProperty("Background")]
        public Background Background { get; set; }

        [JsonProperty("Time")]
        public Time Time { get; set; }

        [JsonProperty("Date")]
        public Date Date { get; set; }

        [JsonProperty("StepsProgress")]
        public StepsProgress StepsProgress { get; set; }

        [JsonProperty("Status")]
        public Status Status { get; set; }
    }

    public partial class Background {
        [JsonProperty("Image")]
        public Image Image { get; set; }
    }

    public partial class Image {
        [JsonProperty("X")]
        public int X { get; set; }

        [JsonProperty("Y")]
        public int Y { get; set; }

        [JsonProperty("ImageIndex")]
        public int ImageIndex { get; set; }

        [JsonProperty("ImagesCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? ImagesCount { get; set; }
    }

    public partial class Date {
        [JsonProperty("MonthAndDay")]
        public MonthAndDay MonthAndDay { get; set; }

        [JsonProperty("WeekDay")]
        public Image WeekDay { get; set; }

        [JsonProperty("DayAmPm")]
        public DayAmPm DayAmPm { get; set; }
    }

    public partial class DayAmPm {
        [JsonProperty("TopLeftX")]
        public int TopLeftX { get; set; }

        [JsonProperty("TopLeftY")]
        public int TopLeftY { get; set; }

        [JsonProperty("ImageIndexAMCN")]
        public int ImageIndexAmcn { get; set; }

        [JsonProperty("ImageIndexPMCN")]
        public int ImageIndexPmcn { get; set; }

        [JsonProperty("ImageIndexAMEN")]
        public int ImageIndexAmen { get; set; }

        [JsonProperty("ImageIndexPMEN")]
        public int ImageIndexPmen { get; set; }
    }

    public partial class MonthAndDay {
        [JsonProperty("OneLine")]
        public OneLine OneLine { get; set; }

        [JsonProperty("TwoDigitsMonth")]
        public bool TwoDigitsMonth { get; set; }

        [JsonProperty("TwoDigitsDay")]
        public bool TwoDigitsDay { get; set; }
    }

    public partial class OneLine {
        [JsonProperty("Number")]
        public Text2 Number { get; set; }

        [JsonProperty("DelimiterImageIndex")]
        public int DelimiterImageIndex { get; set; }
    }

    public partial class Text2 {
        [JsonProperty("TopLeftX")]
        public int TopLeftX { get; set; }

        [JsonProperty("TopLeftY")]
        public int TopLeftY { get; set; }

        [JsonProperty("BottomRightX")]
        public int BottomRightX { get; set; }

        [JsonProperty("BottomRightY")]
        public int BottomRightY { get; set; }

        [JsonProperty("Alignment")]
        public string Alignment { get; set; }

        [JsonProperty("Spacing")]
        public int Spacing { get; set; }

        [JsonProperty("ImageIndex")]
        public int ImageIndex { get; set; }

        [JsonProperty("ImagesCount")]
        public int ImagesCount { get; set; }
    }

    public partial class Status {
        [JsonProperty("Alarm")]
        public Alarm Alarm { get; set; }

        [JsonProperty("Lock")]
        public Alarm Lock { get; set; }

        [JsonProperty("Bluetooth")]
        public Bluetooth Bluetooth { get; set; }

        [JsonProperty("Battery")]
        public Battery Battery { get; set; }
    }

    public partial class Alarm {
        [JsonProperty("Coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("ImageIndexOn")]
        public int ImageIndexOn { get; set; }
    }

    public partial class Coordinates {
        [JsonProperty("X")]
        public int X { get; set; }

        [JsonProperty("Y")]
        public int Y { get; set; }

        [JsonProperty("X2")]
        public int X2 { get; set; }

        [JsonProperty("Y2")]
        public int Y2 { get; set; }

        [JsonProperty("X3")]
        public int X3 { get; set; }
    }

    public partial class Battery {
        [JsonProperty("Text")]
        public Text Text { get; set; }

        [JsonProperty("Text2")]
        public Text2 Text2 { get; set; }

        [JsonProperty("Icon")]
        public Image Icon { get; set; }
    }

    public partial class Text {
        [JsonProperty("TopLeftX")]
        public int TopLeftX { get; set; }

        [JsonProperty("TopLeftY")]
        public int TopLeftY { get; set; }

        [JsonProperty("BottomRightX")]
        public int BottomRightX { get; set; }

        [JsonProperty("BottomRightY")]
        public int BottomRightY { get; set; }

        [JsonProperty("Alignment")]
        public int Alignment { get; set; }

        [JsonProperty("Spacing")]
        public int Spacing { get; set; }

        [JsonProperty("ImageIndex")]
        public int ImageIndex { get; set; }

        [JsonProperty("ImagesCount")]
        public int ImagesCount { get; set; }
    }

    public partial class Bluetooth {
        [JsonProperty("Coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("ImageIndexOff")]
        public int ImageIndexOff { get; set; }
    }

    public partial class StepsProgress {
        [JsonProperty("Linear")]
        public Linear Linear { get; set; }
    }

    public partial class Linear {
        [JsonProperty("StartImageIndex")]
        public int StartImageIndex { get; set; }

        [JsonProperty("Segments")]
        public Segment[] Segments { get; set; }
    }

    public partial class Segment {
        [JsonProperty("X")]
        public int X { get; set; }

        [JsonProperty("Y")]
        public int Y { get; set; }
    }

    public partial class Time {
        [JsonProperty("Hours")]
        public Hours Hours { get; set; }

        [JsonProperty("Minutes")]
        public Hours Minutes { get; set; }
    }

    public partial class Hours {
        [JsonProperty("Tens")]
        public Image Tens { get; set; }

        [JsonProperty("Ones")]
        public Image Ones { get; set; }
    }

    public partial class SkinManifestJson {
        public static SkinManifestJson FromJson(string json) => JsonConvert.DeserializeObject<SkinManifestJson>(json, Converter.Settings);
    }

    public static class Serialize {
        public static string ToJson(this SkinManifestJson self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}