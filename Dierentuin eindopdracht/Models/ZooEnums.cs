namespace Dierentuin_eindopdracht.Models
{
    public class ZooEnums
    {
        //Animal enums
        public enum Size
        {
            Microscopic = 1,
            VerySmall = 2,
            Small = 3,
            Medium = 4,
            Large = 5,
            VeryLarge = 6,
        }
        public enum DietaryClass
        {
            Carnivore = 1,
            Herbivore = 2,
            Omnivore = 3,
            Insectivore = 4,
            Piscivore = 5,
        }
        public enum ActivityPattern
        {
            Diurnal = 1,
            Nocturnal = 2,
            Cathermal = 3,
        }
        //Enclosure enums
        public enum Climate
        {
            Tropical = 1,
            Temperate = 2,
            Arctic = 3,
        }

        [Flags]
        public enum HabitatType
        {
            None = 0,
            Forest = 1,
            Aquatic = 2,
            Desert = 4,
            Grassland = 8,
        }
        public enum SecurityLevel
        {
            Low = 1,
            Medium = 2,
            High = 3,
        }

    }
}
