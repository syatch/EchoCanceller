using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace echo_canceller
{
	//リングバッファです
	public class WaveBuffer
	{
		float[] buffer;
		int headIndex; //一番新しいデータのインデックス
		int tailIndex; //一番古いデータのインデックス

		public int BufferedLength
		{
			get
			{
				return headIndex - tailIndex;
			}
		}

		public WaveBuffer(int size = 2048)
		{
			buffer = new float[size];
			headIndex = 0;
			tailIndex = 0;
		}

		//バッファにデータを追加します
		public void Add(float data)
		{
			buffer[headIndex++ % buffer.Length] = data;
		}

		//countだけバッファを消費します
		public float[] Read(int count)
		{
			var rv = new float[count];
			for (int i = 0; i < count; i++)
			{
				rv[i] = buffer[tailIndex++];
			}

			return rv;
		}
	}
}
