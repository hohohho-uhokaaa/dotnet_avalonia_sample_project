using System;
using System.Globalization;
using System.Resources;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace HelloAvalonia;

public partial class MainWindow : Window
{
    // Resources.resxを現在のUIカルチャに応じて読み込むためのマネージャーです。
    private static readonly ResourceManager TextResources = new(
        "HelloAvalonia.Resources",
        typeof(MainWindow).Assembly);

    // XAMLで名前を付けたコントロールを、コードビハインドから操作します。
    private readonly TextBlock _headerText;
    private readonly TextBox _messageTextBox;
    private readonly Button _showButton;

    public MainWindow()
    {
        // XAMLを初期化してから、x:Nameで指定したコントロールを取得します。
        InitializeComponent();

        // AvaloniaではFindControlで名前付きコントロールを取得します。
        // XAML側の名前が変更・削除された場合、起動時に原因が分かる例外を出します。
        _headerText = this.FindControl<TextBlock>("HeaderText")
            ?? throw new InvalidOperationException("HeaderText was not found in MainWindow.axaml.");
        _messageTextBox = this.FindControl<TextBox>("MessageTextBox")
            ?? throw new InvalidOperationException("MessageTextBox was not found in MainWindow.axaml.");
        _showButton = this.FindControl<Button>("ShowButton")
            ?? throw new InvalidOperationException("ShowButton was not found in MainWindow.axaml.");

        // 表示文言はResources.resxから取得し、XAMLの見た目設定と分離します。
        Title = GetText("WindowTitle");
        _headerText.Text = GetText("HeaderTitle");
        _messageTextBox.Watermark = GetText("MessageWatermark");
        _showButton.Content = GetText("ShowButtonText");
    }

    // 指定カルチャの文字列を返し、未定義キーの場合はキー名をフォールバック表示します。
    private static string GetText(string key) =>
        TextResources.GetString(key, CultureInfo.CurrentUICulture) ?? key;

    // ボタン操作に応じて、リソースファイルのメッセージを入力欄に表示します。
    private void OnShowMessageClick(object? sender, RoutedEventArgs e)
    {
        _messageTextBox.Text = GetText("HelloMessage");
    }
}
