using ICSharpCode.SharpZipLib.GZip;
using System.IO;
using System.Text;

namespace UniGzipCompressor
{
	/// <summary>
	/// gzip で文字列の圧縮や解凍を行うクラス
	/// </summary>
	public static class GzipCompressor
	{
		/// <summary>
		/// 圧縮します
		/// </summary>
		public static byte[] Compress( string rawString )
		{
			var rawData = Encoding.UTF8.GetBytes( rawString );
			using ( var memoryStream = new MemoryStream() )
			{
				CompressImpl( memoryStream, rawData );
				return memoryStream.ToArray();
			}
		}

		/// <summary>
		/// 解凍します
		/// </summary>
		public static string Decompress( byte[] compressedData )
		{
			using ( var memoryStream = new MemoryStream() )
			{
				DecompressImpl( memoryStream, compressedData );
				var bytes = memoryStream.ToArray();
				return Encoding.UTF8.GetString( bytes );
			}
		}

		/// <summary>
		/// 圧縮します
		/// </summary>
		private static void CompressImpl( Stream stream, byte[] rawData )
		{
			using ( var gzipOutputStream = new GZipOutputStream( stream ) )
			{
				gzipOutputStream.Write( rawData, 0, rawData.Length );
			}
		}

		/// <summary>
		/// 解凍します
		/// </summary>
		private static void DecompressImpl( Stream stream, byte[] compressedData )
		{
			var buffer = new byte[4096];
			using ( var memoryStream = new MemoryStream( compressedData ) )
			using ( var gzipOutputStream = new GZipInputStream( memoryStream ) )
			{
				for ( int r = -1; r != 0; r = gzipOutputStream.Read( buffer, 0, buffer.Length ) )
				{
					if ( r > 0 )
					{
						stream.Write( buffer, 0, r );
					}
				}
			}
		}
	}
}