namespace MainMenu
{
    public class MainMenuController: MainMenuControllerAbstract
    {
        public MainMenuController(MainMenuModelAbstract model, MainMenuViewAbstract view) : base(model, view)
        {
            Subscribe();
        }
        
        public override void Dispose()
        {
            Unsubscribe();
        }

        public override void Subscribe()
        {
            _view.OnStartGameButtonClick += _model.StartGame;
            _view.OnQuitButtonClick += _model.Quit;
            _view.Subscribe();
        }

        public override void Unsubscribe()
        {
            _view.OnStartGameButtonClick -= _model.StartGame;
            _view.OnQuitButtonClick -= _model.Quit;
            _view.Unsubscribe();
        }
    }
}