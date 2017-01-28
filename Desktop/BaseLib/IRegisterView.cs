namespace Desktop.BaseLib
{
    interface IRegisterView : IView
    {
        string Email { get; set; }
        string Password { get; set; }
        string FirstName { get; }
        string LastName { get; }
    }
}
