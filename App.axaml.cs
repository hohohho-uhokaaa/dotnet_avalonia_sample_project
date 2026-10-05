using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace HelloAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        // App.axamlからテーマと共有リソースを読み込みます。
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // デスクトップ実行時はメインウィンドウを生成してアプリに登録します。
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
