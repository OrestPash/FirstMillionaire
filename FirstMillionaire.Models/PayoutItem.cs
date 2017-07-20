namespace FirstMillionaire.Models
{
    public struct PayoutItem
    {       
        public int Prize { get; set; }        

        public bool IsSafeHaven { get; set; }

        public Complexity QuestionComplexity { get; set; }
    }  
}
