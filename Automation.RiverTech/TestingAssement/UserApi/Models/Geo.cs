﻿using Newtonsoft.Json;

namespace TestingAssessment.UserApi.Models
{
    public partial class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
}