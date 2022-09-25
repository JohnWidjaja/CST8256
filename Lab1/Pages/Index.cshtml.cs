using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public double MaxAmount { get; set; }
        public double MinAmount { get; set; }
        public double TotalAmount { get; set; }
        public double AvgAmount { get; set; }
        public List<double> numberList { get; set; }
        public string? ErrorMessage { get; set; }

        [BindProperty]
        public string? FirstNumber { get; set; }
        [BindProperty]
        public string? SecondNumber { get; set; }
        [BindProperty]
        public string? ThirdNumber { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //initialize double list
            numberList = new List<double>();
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            //check if user input can be parsed into number, if not do not enter into list.
            if (double.TryParse(FirstNumber,out double firstNumber))
            {
                numberList.Add(firstNumber);
            }
            if (double.TryParse(SecondNumber, out double secondNumber))
            {
                numberList.Add(secondNumber);
            }
            if (double.TryParse(ThirdNumber, out double thirdNumber))
            {
                numberList.Add(thirdNumber);
            }

            if(numberList.Count == 0)
            {
                ErrorMessage = "You did not enter any number, no statistics were calculated.";
            }

            if (numberList.Count != 0)
            {
                //set min and max to the first element in the list which is the first number
                MaxAmount = numberList[0];
                MinAmount = numberList[0];
                //loop through the array the find the max and min number result
                foreach (double i in numberList)
                {
                    if (i > MaxAmount)
                    {
                        MaxAmount = i;
                    }
                    if (i < MinAmount)
                    {
                        MinAmount = i;
                    }
                    //add all list elements to a total
                    TotalAmount += i;
                }
                //avgNumResult = totalNumResult / numberList.Length;
                AvgAmount = numberList.Average();
            }

        }

        //public void 
    }
}