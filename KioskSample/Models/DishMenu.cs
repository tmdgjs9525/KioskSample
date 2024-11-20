using KioskSample.Core.Models;

namespace KioskSample.Models
{
    public class DishMenu
    {
        private static readonly Money Zero_Money = new Money(0, "KRW");

        public int Id { get; set; }

        public string Category { get; set; } = "메인메뉴";

        public required string Name { get; set; }

        private Money _price = Zero_Money;
        public required Money Price
        {
            get
            {
                return _price;
            }
            set 
            {
                if (value < Zero_Money)
                {
                    throw new ArgumentException("가격은 0원 이하일 수 없습니다");
                }

                _price = value;
            }
        }
    }
}
