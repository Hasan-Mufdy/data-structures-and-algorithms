using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace business_trip_unittests
{
    public class UnitTest1
    {
        [Fact]
        public void Check_If_BusinessTripCost_Is_Returning_Correct_Output()
        {
            var graph = CreateGraph();

            string[] n1 = { "Metroville", "Pandora" };
            int expectedCost1 = 82;
            int? expected1 = expectedCost1;

            string[] n2 = { "Arendelle", "Monstropolis" };
            int expectedCost2 = 42;
            int? expected2 = expectedCost2;

            string[] n3 = { "Naboo", "Pandora" };
            int? expected3 = null;

            string[] n4 = { "Narnia", "Arendelle", "Naboo" };
            int? expected4 = null;

            int? result1 = Program.BusinessTripCost(graph, n1);
            int? result2 = Program.BusinessTripCost(graph, n2);
            int? result3 = Program.BusinessTripCost(graph, n3);
            int? result4 = Program.BusinessTripCost(graph, n4);

            Assert.Equal(expected1, result1);
            Assert.Equal(expected2, result2);
            Assert.Equal(expected3, result3);
            Assert.Equal(expected4, result4);
        }



        private Dictionary<string, Dictionary<string, int>> CreateGraph()
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();

            graph["Metroville"] = new Dictionary<string, int>
    {
        { "Pandora", 82 },
        { "Narnia", 37 }
    };

            graph["Pandora"] = new Dictionary<string, int>
    {
        { "Metroville", 82 },
        { "Arendelle", 150 }
    };

            graph["Arendelle"] = new Dictionary<string, int>
    {
        { "Pandora", 150 },
        { "Monstropolis", 42 },
        { "Metroville", 99 }
    };

            graph["New Monstropolis"] = new Dictionary<string, int>
    {
        { "Arendelle", 42 },
        { "Metroville", 105 },
        { "Naboo", 73 }
    };

            graph["Naboo"] = new Dictionary<string, int>
    {
        { "Monstropolis", 73 },
        { "Metroville", 26 },
        { "Narnia", 250 }
    };

            graph["Narnia"] = new Dictionary<string, int>
    {
        { "Metroville", 37 },
        { "Naboo", 250 }
    };

            return graph;
        }


    }
}