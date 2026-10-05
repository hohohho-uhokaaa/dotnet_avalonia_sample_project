# HelloAvalonia

Fedora 44 環境（.NET 10）で動作する、Avalonia UI の最小構成・入門向け練習プロジェクトです。  
ボタンをクリックすると、リソースファイル（`Resources.resx`）からメッセージを取得してテキストボックスに文字列を表示するシンプルな挙動を実装しています。

> **Note**  
> 本プロジェクトのソースコード、ファイル構造、および `Resources.resx` による文字列のリソースファイル化（多言語化対応の基礎構成）は、**Zed の AI モデル（gpt-6 luna）** によって自動生成・実装されたものです。

---

## 💡 プロジェクトの目的

* Avalonia UI の最も基本的な画面構成（XAML）とコードビハインド（C#）の連携を理解する。
* ボタンイベント（`Click`）のハンドリング方法を確認する。
* UI 内の固定文言を直接書き込まず、`.resx` リソースファイル経由で動的に設定する方法を学ぶ。

---

## 📁 プロジェクトの最小構成と役割

プロジェクト内の主要なファイルとその役割は以下の通りです。

```text
HelloAvalonia/
├── HelloAvalonia.csproj   # プロジェクトの定義・依存関係（Avalonia Packages, .NET 10等）
├── MainWindow.axaml        # 画面レイアウト（UIデザイン・コントロール配置）
├── MainWindow.axaml.cs     # 画面ロジック（イベント処理・リソースからの文言設定）
├── Resources.resx          # アプリ内で使用する各種テキストリソース
├── Program.cs              # アプリケーションのエントリポイント（描画エンジン初期化）
├── App.axaml / App.axaml.cs# アプリ全体の初期化・テーマ設定
└── Styles/                 # ウィンドウサイズや色、余白などの各種スタイル定義
```

---

## 🔍 主要コードの解説

### 1. `HelloAvalonia.csproj`（設定ファイル）
.NET 10 ターゲット設定および Avalonia UI の基本パッケージ群（`Avalonia.Desktop`, `FluentTheme` 等）が記述されています。

### 2. `MainWindow.axaml`（画面レイアウト）
`Grid` や `StackPanel` を使って以下のコントロールを配置しています。
* **`TextBlock` (`HeaderText`)**: 見出しラベル
* **`TextBox` (`MessageTextBox`)**: メッセージ表示・入力欄
* **`Button` (`ShowButton`)**: メッセージ表示をトリガーするボタン

サイズや背景色などのスタイルは、XAML 内で直書きせず `StaticResource` を介して一括管理されています。

### 3. `MainWindow.axaml.cs`（コードビハインド）
* `InitializeComponent()` 呼出後、`FindControl<T>()` を使って XAML 上の要素（`HeaderText`, `MessageTextBox`, `ShowButton`）を取得します。
* `ResourceManager` を使用し、起動時に `Resources.resx` から現在の環境カルチャに応じたテキストを取得して各コントロールへ初期設定（`Title`, `Watermark` 等）します。
* ボタン押下イベント `OnShowMessageClick` が発火すると、リソースから取得した文字列（`HelloMessage`）を `TextBox` に設定します。

---

## 🚀 実行方法

ターミナルでプロジェクトディレクトリに移動し、以下のコマンドを実行します。

```bash
# ビルドと実行
dotnet run
```

画面が表示されたら、「表示する」ボタンをクリックすることでメッセージが入力欄に反映される動作を確認できます。