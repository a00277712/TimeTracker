using Microsoft.AspNetCore.Components;

namespace TimeTracker.Client.Pages.Errors
{
    public partial class NotFound
    {
		[Inject]
		public NavigationManager Nav { get; set; }

		public void NavigateToHome()
		{
			Nav.NavigateTo("/");
		}
	}
}
