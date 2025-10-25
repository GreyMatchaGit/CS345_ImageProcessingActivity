using System;

namespace ImageProcessPractice
{
	public class Conv3x3Config
	{
		public static Convolution3x3 GaussianBlur = new Convolution3x3(
			new int[] {
			1, 2, 1,
			2, 4, 2,
			1, 2, 1
			},
			16,
			0
		);

		public static Convolution3x3 Sharpen = new Convolution3x3(
			new int[] {
			0, -2, 0,
			-2, 11, -2,
			0, -2, 0
			},
			3,
			0
		);

		public static Convolution3x3 MeanRemoval = new Convolution3x3(
			new int[] {
			-1, -1, -1,
			-1, 9, -1,
			-1, -1, -1
			},
			1,
			0
		);

		public static Convolution3x3 EmbossLaplascian = new Convolution3x3(
			new int[] {
			-1, 0, -1,
			0, 4, 0,
			-1, 0, -1
			},
			1,
			127
		);
	}
}
