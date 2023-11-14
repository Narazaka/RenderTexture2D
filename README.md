# RenderTexture2D

Render Texture to Texture2D

## About

カメラに写ったRender Textureの色を指定のTexture2Dに書き込みます。

## Install

### VCCによる方法

1. https://vpm.narazaka.net/ から「Add to VCC」ボタンを押してリポジトリをVCCにインストールします。
2. VCCでSettings→Packages→Installed Repositoriesの一覧中で「Narazaka VPM Listing」にチェックが付いていることを確認します。
3. アバタープロジェクトの「Manage Project」から「RenderTexture2D」をインストールします。

## 使い方

RenderTextureを付けたカメラに「RenderTexture2D」コンポーネントを追加し、以下の設定のTexture2Dを設定します。

- Read/Write Enabled
- sRGB=OFF
- カメラのRenderTextureとサイズが同じ

`RenderTexture2D.Render()`を呼べばTexture2Dに描画されるはずです。

## 更新履歴

- 1.0.0
  - リリース

## License

[Zlib License](LICENSE.txt)
