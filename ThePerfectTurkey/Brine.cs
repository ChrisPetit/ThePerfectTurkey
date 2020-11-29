using System;

namespace ThePerfectTurkey
{
    public class Brine
    {
        public Brine(Turkey turkey)
        {
            Turkey = turkey;
            Salt = 0.05 * Turkey.Weight;
            Water = 0.66 * Turkey.Weight;
            BrownSugar = 0.13 * Turkey.Weight;
            Shallots = 0.2 * Turkey.Weight;
            ClovesOfGarlic = 0.4 * Turkey.Weight;
            WholePeppercorns = 0.13 * Turkey.Weight;
            DriedJuniperBerries = 0.13 * Turkey.Weight;
            FreshRosemary = 0.13 * Turkey.Weight;
            Thyme = 0.06 * Turkey.Weight;
            BrineTime = 2.4 * Turkey.Weight;
            RoastTime = 15 * Turkey.Weight;
        }

        private Turkey Turkey { get; set; }
        private double Salt { get; set; }
        private double Water { get; set; }
        private double BrownSugar { get; set; }
        private double Shallots { get; set; }
        private double ClovesOfGarlic { get; set; }
        private double WholePeppercorns { get; set; }
        private double DriedJuniperBerries { get; set; }
        private double FreshRosemary { get; set; }
        private double Thyme { get; set; }
        private double BrineTime { get; set; }
        private double RoastTime { get; set; }

        public string CreateRecipe()
        {
            var recipe = $"Here is your recipe:{Environment.NewLine}" +
                         $"{Salt} cups of salt{Environment.NewLine}" +
                         $"{Water} gallons of water{Environment.NewLine}" +
                         $"{BrownSugar} cups of brown sugar{Environment.NewLine}" +
                         $"{Shallots} shallots{Environment.NewLine}" +
                         $"{ClovesOfGarlic} cloves of garlic{Environment.NewLine}" +
                         $"{WholePeppercorns} tablespoons of whole peppercorns{Environment.NewLine}" +
                         $"{DriedJuniperBerries} tablespoons of dried juniper berries{Environment.NewLine}" +
                         $"{FreshRosemary} tablespoons of fresh rosemary{Environment.NewLine}" +
                         $"{Thyme} tablespoons of thyme{Environment.NewLine}" + $"{Environment.NewLine}" +
                         $"Brine Time: {BrineTime} hours{Environment.NewLine}" +
                         $"Roast Time: {RoastTime} minutes{Environment.NewLine}";
            return recipe;
        }
    }
}