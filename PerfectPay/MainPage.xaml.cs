namespace PerfectPay;

public partial class MainPage : ContentPage
{
    public int Tip { get; set; }

    public decimal Bill { get; set; }

    public int PersonCount { get; set; } = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
        Bill = Convert.ToDecimal(txtBill.Text);
        CalculateTotal();
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {

            var btn = (Button)sender;

            var percentage = btn.Text.Replace("%", "");

            sldTip.Value = int.Parse(percentage);
        }
    }


    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Tip = Convert.ToInt32(sldTip.Value);
        lblTip.Text = $"Tip : {Tip}%";
        CalculateTotal();
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (PersonCount > 1)
        {
            PersonCount--;
        }
        
        lblNoPerons.Text = PersonCount.ToString();

        CalculateTotal();

    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        
        PersonCount++;
        
        lblNoPerons.Text = PersonCount.ToString();

        CalculateTotal();
    }
    private void CalculateTotal()
    {
        var totalTip = (Bill * Tip) / 100;

        var topPerPerson = totalTip / PersonCount;

        lblTipByPerson.Text = $"{topPerPerson:C}";

        var subTotal = Bill / PersonCount;

        lblSubtotal.Text = $"{subTotal:C}";

        totalTip = (Bill + totalTip) / PersonCount;

        lblTotal.Text = $"{totalTip:C}";

    }

}

