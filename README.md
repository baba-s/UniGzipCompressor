# Uni Gzip Compressor

gzip で文字列を圧縮する機能

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var rawData        = "ピカチュウ";
        var compressedData = GzipCompressor.Compress( rawData );
        var result         = GzipCompressor.Decompress( compressedData );

        Debug.Log( result );
    }
}
```

## ライセンス

* このリポジトリは MIT ライセンスの「SharpCompress」を使用させていただいています  
https://github.com/adamhathcock/sharpcompress  

## 関連記事

* http://baba-s.hatenablog.com/entry/2017/08/24/100000
