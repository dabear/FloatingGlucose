/*
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0

 Adapted from http://xmltocsharp.azurewebsites.net/ by bjorninges.spam@bjorninge.no
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Xml2CSharp
{
    [XmlRoot(ElementName = "timezone")]
    public class Timezone
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "utcoffsetMinutes")]
        public string UtcoffsetMinutes { get; set; }
    }

    [XmlRoot(ElementName = "location")]
    public class Location2
    {
        [XmlAttribute(AttributeName = "altitude")]
        public string Altitude { get; set; }

        [XmlAttribute(AttributeName = "latitude")]
        public string Latitude { get; set; }

        [XmlAttribute(AttributeName = "longitude")]
        public string Longitude { get; set; }

        [XmlAttribute(AttributeName = "geobase")]
        public string Geobase { get; set; }

        [XmlAttribute(AttributeName = "geobaseid")]
        public string Geobaseid { get; set; }
    }

    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "timezone")]
        public Timezone Timezone { get; set; }

        [XmlElement(ElementName = "location2")]
        public Location2 Location2 { get; set; }
    }

    [XmlRoot(ElementName = "link")]
    public class Link
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "credit")]
    public class Credit
    {
        [XmlElement(ElementName = "link")]
        public Link Link { get; set; }
    }

    [XmlRoot(ElementName = "links")]
    public class Links
    {
        [XmlElement(ElementName = "link")]
        public List<Link> Link { get; set; }
    }

    [XmlRoot(ElementName = "meta")]
    public class Meta
    {
        [XmlElement(ElementName = "lastupdate")]
        public string Lastupdate { get; set; }

        [XmlElement(ElementName = "nextupdate")]
        public string Nextupdate { get; set; }
    }

    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "rise")]
        public string Rise { get; set; }

        [XmlAttribute(AttributeName = "set")]
        public string Set { get; set; }
    }

    [XmlRoot(ElementName = "time")]
    public class Time
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "body")]
        public string Body { get; set; }

        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }

        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }

        [XmlElement(ElementName = "symbol")]
        public Symbol Symbol { get; set; }

        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }

        [XmlElement(ElementName = "windDirection")]
        public WindDirection WindDirection { get; set; }

        [XmlElement(ElementName = "windSpeed")]
        public WindSpeed WindSpeed { get; set; }

        [XmlElement(ElementName = "temperature")]
        public Temperature Temperature { get; set; }

        [XmlElement(ElementName = "pressure")]
        public Pressure Pressure { get; set; }
    }

    [XmlRoot(ElementName = "location")]
    public class Location3
    {
        [XmlElement(ElementName = "time")]
        public List<Time> Time { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlElement(ElementName = "location")]
        public Location3 Location3 { get; set; }
    }

    [XmlRoot(ElementName = "symbol")]
    public class Symbol
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }

        [XmlAttribute(AttributeName = "numberEx")]
        public string NumberEx { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "var")]
        public string Var { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }

    [XmlRoot(ElementName = "precipitation")]
    public class Precipitation
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "windDirection")]
    public class WindDirection
    {
        [XmlAttribute(AttributeName = "deg")]
        public string Deg { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }

    [XmlRoot(ElementName = "windSpeed")]
    public class WindSpeed
    {
        [XmlAttribute(AttributeName = "mps")]
        public string Mps { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }

    [XmlRoot(ElementName = "temperature")]
    public class Temperature
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }

    [XmlRoot(ElementName = "pressure")]
    public class Pressure
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "tabular")]
    public class Tabular
    {
        [XmlElement(ElementName = "time")]
        public List<Time> Time { get; set; }
    }

    [XmlRoot(ElementName = "forecast")]
    public class Forecast
    {
        [XmlElement(ElementName = "text")]
        public Text Text { get; set; }

        [XmlElement(ElementName = "tabular")]
        public Tabular Tabular { get; set; }
    }

    [XmlRoot(ElementName = "weatherstation")]
    public class Weatherstation
    {
        [XmlElement(ElementName = "symbol")]
        public Symbol Symbol { get; set; }

        [XmlElement(ElementName = "temperature")]
        public Temperature Temperature { get; set; }

        [XmlElement(ElementName = "windDirection")]
        public WindDirection WindDirection { get; set; }

        [XmlElement(ElementName = "windSpeed")]
        public WindSpeed WindSpeed { get; set; }

        [XmlAttribute(AttributeName = "stno")]
        public string Stno { get; set; }

        [XmlAttribute(AttributeName = "sttype")]
        public string Sttype { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "distance")]
        public string Distance { get; set; }

        [XmlAttribute(AttributeName = "lat")]
        public string Lat { get; set; }

        [XmlAttribute(AttributeName = "lon")]
        public string Lon { get; set; }

        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
    }

    [XmlRoot(ElementName = "observations")]
    public class Observations
    {
        [XmlElement(ElementName = "weatherstation")]
        public List<Weatherstation> Weatherstation { get; set; }
    }

    [XmlRoot(ElementName = "weatherdata")]
    public class Weatherdata
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }

        [XmlElement(ElementName = "credit")]
        public Credit Credit { get; set; }

        [XmlElement(ElementName = "links")]
        public Links Links { get; set; }

        [XmlElement(ElementName = "meta")]
        public Meta Meta { get; set; }

        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }

        [XmlElement(ElementName = "forecast")]
        public Forecast Forecast { get; set; }

        [XmlElement(ElementName = "observations")]
        public Observations Observations { get; set; }
    }
}