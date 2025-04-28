using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SilverRAT.StreamLibrary.src;

public class LzwCompression
{
    private readonly EncoderParameter parameter;

    private readonly ImageCodecInfo encoderInfo;

    private readonly EncoderParameters encoderParams;

    public LzwCompression(int Quality)
    {
        parameter = new EncoderParameter(Encoder.Quality, Quality);
        encoderInfo = GetEncoderInfo("image/jpeg");
        encoderParams = new EncoderParameters(2);
        encoderParams.Param[0] = parameter;
        encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
    }

    public byte[] Compress(Bitmap bmp, byte[] AdditionInfo = null)
    {
        using MemoryStream memoryStream = new MemoryStream();
        if (AdditionInfo != null)
        {
            memoryStream.Write(AdditionInfo, 0, AdditionInfo.Length);
        }
        bmp.Save(memoryStream, encoderInfo, encoderParams);
        return memoryStream.ToArray();
    }

    public void Compress(Bitmap bmp, Stream stream, byte[] AdditionInfo = null)
    {
        if (AdditionInfo != null)
        {
            stream.Write(AdditionInfo, 0, AdditionInfo.Length);
        }
        bmp.Save(stream, encoderInfo, encoderParams);
    }

    private ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        int num = 0;
        while (true)
        {
            if (num < imageEncoders.Length)
            {
                if (imageEncoders[num].MimeType == mimeType)
                {
                    break;
                }
                num++;
                continue;
            }
            return null;
        }
        return imageEncoders[num];
    }
}
