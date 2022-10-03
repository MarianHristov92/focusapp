using Xamarin.Forms;

namespace focusapp.Focus
{
    public class FocusEffect : RoutingEffect
    {
        public FocusEffect() : base($"FocusApp.{nameof(FocusEffect)}")
        {
        }
    }
}