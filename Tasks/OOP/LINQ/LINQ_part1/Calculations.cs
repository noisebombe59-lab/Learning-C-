namespace LINQ_part1
{
    public class Calculations
    {
        public decimal TotalSum(IEnumerable<Goods> goods)
        {
            var totalSum = goods
                .Where(p => p.Category == "Electronics")
                .Sum(p => p.Price * p.Stock);

            return totalSum;
        }
    }
}
