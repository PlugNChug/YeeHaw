using Terraria.UI;

namespace YeeHaw.Common.UI
{
    class MoonPhaseSelector : UIState
    {
        public PlayButton playButton;

        public override void OnInitialize()
        {
            playButton = new PlayButton();

            Append(playButton);
        }
    }
}