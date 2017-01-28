namespace Desktop.BaseLib
{
    public interface ILoginView : IView
    {
        string Email { get; set; }
        string Password { get; set;  }
    }
}
