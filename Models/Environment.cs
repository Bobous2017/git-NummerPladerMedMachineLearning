using Newtonsoft.Json;

namespace NummerPlader.Models
{
    public class Environment
    {
        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("fuel_type")]
        public string FuelType { get; set; }

        [JsonProperty("fuel_usage")]
        public string FuelUsage { get; set; }

        [JsonProperty("electric_usage")]
        public string ElectricUsage { get; set; }

        [JsonProperty("total_usage")]
        public string TotalUsage { get; set; }

        [JsonProperty("co2_emission")]
        public string Co2Emission { get; set; }

        [JsonProperty("co_emission")]
        public string CoEmission { get; set; }

        [JsonProperty("hc_nox_emission")]
        public string HcNoxEmission { get; set; }

        [JsonProperty("nox_emission")]
        public string NoxEmission { get; set; }

        [JsonProperty("particles")]
        public string Particles { get; set; }

        [JsonProperty("particle_filter")]
        public string ParticleFilter { get; set; }

        [JsonProperty("idle_noise")]
        public string IdleNoise { get; set; }

        [JsonProperty("idle_noise_rpm")]
        public string IdleNoiseRpm { get; set; }

        [JsonProperty("driving_noise")]
        public string DrivingNoise { get; set; }

        [JsonProperty("euro_norm")]
        public string EuroNorm { get; set; }

        [JsonProperty("innovation_technology")]
        public string InnovationTechnology { get; set; }

        [JsonProperty("co2_savings")]
        public string Co2Savings { get; set; }
    }
}
