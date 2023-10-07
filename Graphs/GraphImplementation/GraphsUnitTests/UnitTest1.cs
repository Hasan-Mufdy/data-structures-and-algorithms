using GraphDemo;

namespace GraphsUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddVertex_ShouldAddVertexToGraph()
        {
            var graph = new Graph<int>();

            var vertex = graph.AddVertex(42);

            Assert.Equal(1, graph.Size);
            Assert.True(graph.GetVertices().Contains(vertex));
        }

        [Fact]
        public void AddEdge_ShouldAddEdgeBetweenVertices()
        {
            var graph = new Graph<string>();
            var vertex1 = graph.AddVertex("A");
            var vertex2 = graph.AddVertex("B");

            graph.AddEdge(vertex1, vertex2);

            var neighborsOfVertex1 = graph.GetNeighbors(vertex1);
            var neighborsOfVertex2 = graph.GetNeighbors(vertex2);

            Assert.Single(neighborsOfVertex1);
            Assert.Single(neighborsOfVertex2);
            Assert.Equal(vertex2.Value, neighborsOfVertex1.First().Vertex.Value);
            Assert.Equal(vertex1.Value, neighborsOfVertex2.First().Vertex.Value);
        }

        [Fact]
        public void GetVertices_ShouldReturnAllVerticesInGraph()
        {
            var graph = new Graph<char>();
            var vertex1 = graph.AddVertex('A');
            var vertex2 = graph.AddVertex('B');
            var vertex3 = graph.AddVertex('C');

            var vertices = graph.GetVertices();

            Assert.Equal(3, vertices.Count);
            Assert.Contains(vertex1, vertices);
            Assert.Contains(vertex2, vertices);
            Assert.Contains(vertex3, vertices);
        }

        [Fact]
        public void GetNeighbors_ShouldReturnNeighborsOfVertex()
        {
            var graph = new Graph<int>();
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            graph.AddEdge(vertex1, vertex2, 10);
            graph.AddEdge(vertex1, vertex3, 20);

            var neighborsOfVertex1 = graph.GetNeighbors(vertex1);

            Assert.Equal(2, neighborsOfVertex1.Count);
            Assert.Contains(neighborsOfVertex1, edge => edge.Vertex.Value == vertex2.Value && edge.Weight == 10);
            Assert.Contains(neighborsOfVertex1, edge => edge.Vertex.Value == vertex3.Value && edge.Weight == 20);
        }
        ///// breadth first
        [Fact]
        public void BreadthFirstTraversalShouldTraverseInCorrectOrder()
        {
            var graph = new Graph<string>();
            var vertexA = graph.AddVertex("Pandora");
            var vertexB = graph.AddVertex("Arendelle");
            var vertexC = graph.AddVertex("Metroville");
            var vertexD = graph.AddVertex("Monstroplolis");
            var vertexE = graph.AddVertex("Narnia");
            var vertexF = graph.AddVertex("Naboo");

            graph.AddEdge(vertexA, vertexB);
            graph.AddEdge(vertexB, vertexC);
            graph.AddEdge(vertexC, vertexD);
            graph.AddEdge(vertexD, vertexE);
            graph.AddEdge(vertexE, vertexF);

            var result = graph.BreadthFirstTraversal(vertexA);

            Assert.Collection(result,
                vertex => Assert.Equal("Pandora", vertex.Value),
                vertex => Assert.Equal("Arendelle", vertex.Value),
                vertex => Assert.Equal("Metroville", vertex.Value),
                vertex => Assert.Equal("Monstroplolis", vertex.Value),
                vertex => Assert.Equal("Narnia", vertex.Value),
                vertex => Assert.Equal("Naboo", vertex.Value)
            );
        }

        [Fact]
        public void BreadthFirstTraversalInvalidStartVertexShouldThrowException()
        {
            var graph = new Graph<string>();
            var invalidVertex = new Vertex<string>("InvalidVertex");

            var exception = Assert.Throws<InvalidOperationException>(() => graph.BreadthFirstTraversal(invalidVertex));
            Assert.Equal("Start vertex is not in the graph.", exception.Message);
        }
        //////////////////////

        [Fact]
        public void TestDepthFirstPreOrderTraversal()
        {
            Graph<string> graph2 = new Graph<string>();

            Vertex<string> a2 = graph2.AddVertex("a");
            Vertex<string> b2 = graph2.AddVertex("b");
            Vertex<string> c2 = graph2.AddVertex("c");
            Vertex<string> d2 = graph2.AddVertex("d");
            Vertex<string> e2 = graph2.AddVertex("e");
            Vertex<string> f2 = graph2.AddVertex("f");
            Vertex<string> g2 = graph2.AddVertex("g");
            Vertex<string> h2 = graph2.AddVertex("h");

            graph2.AddEdge(a2, b2);
            graph2.AddEdge(a2, d2);

            graph2.AddEdge(b2, c2);
            graph2.AddEdge(b2, d2);

            graph2.AddEdge(c2, g2);

            graph2.AddEdge(d2, e2);
            graph2.AddEdge(d2, h2);
            graph2.AddEdge(d2, f2);
            // graph2.AddEdge(d2, a2);
            // graph2.AddEdge(d2, b2);

            // graph2.AddEdge(e2, d2);
            // graph2.AddEdge(f2, d2);
            graph2.AddEdge(f2, h2);

            //graph2.AddEdge(g2, h2);
            graph2.AddEdge(h2, f2);
            graph2.AddEdge(h2, d2);

            var dfsPreOrder = graph2.DepthFirstPreOrderTraversal(a2);

            var dfsPreOrderList = dfsPreOrder.Select(v => v.Value).ToList();

            List<string> expectedPreOrder = new List<string> { "a", "b", "c", "g", "d", "e", "h", "f" };

            Assert.Equal(expectedPreOrder, dfsPreOrderList);
        }
    }
}