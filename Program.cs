using Avalonia;
using System;

namespace HelloAvalonia;

class Program
{
    // Avaloniaの初期化が完了する前にUIや外部APIを呼び出すと、初期化順序の問題が起きます。
    // STAThreadはデスクトップUIアプリの実行モデルに必要です。
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avaloniaアプリを構成します。このメソッドはデザイナーからも使用されます。
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect() // 実行環境に応じたウィンドウシステムを選択します。
            .WithInterFont() // UIで使用するInterフォントを有効にします。
            .LogToTrace(); // Avaloniaの診断ログをTraceに出力します。
}
