namespace Tests.DataBuilder
{
    public static class TouristFactory
    {
        public static ITouristDatabuilder CreateTourist(int id, string firstname, string lastname)
        {
            var x = new TouristDataBuilder();

            return x.CreateTourist(id, firstname, lastname);
        }
    }
}