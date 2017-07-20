using FirstMillionaire.Domain.Enums;
 
namespace FirstMillionaire.Domain.ValueObjects
{
    public struct PayoutItem
    {       
        public int Prize { get; set; }        

        public bool IsSafeHaven { get; set; }

        public Complexity QuestionComplexity { get; set; }
    }  
}
