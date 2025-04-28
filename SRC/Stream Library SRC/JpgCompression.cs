using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SilverRAT.StreamLibrary.src;

public class JpgCompression
{
    private readonly EncoderParameter parameter;

    private readonly ImageCodecInfo encoderInfo;

    private readonly EncoderParameters encoderParams;

    public JpgCompression(int Quality)
    {
        parameter = new EncoderParameter(Encoder.Quality, Quality);
        encoderInfo = GetEncoderInfo("image/jpeg");
        encoderParams = new EncoderParameters(2);
        encoderParams.Param[0] = parameter;
        encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && encoderParams != null)
        {
            encoderParams.Dispose();
        }
    }

    public byte[] Compress(Bitmap bmp)
    {
        using MemoryStream memoryStream = new MemoryStream();
        bmp.Save(memoryStream, encoderInfo, encoderParams);
        return memoryStream.ToArray();
    }

    public void Compress(Bitmap bmp, ref Stream TargetStream)
    {
        bmp.Save(TargetStream, encoderInfo, encoderParams);
    }

    private ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        int num = imageEncoders.Length - 1;
        int num2 = 0;
        while (true)
        {
            if (num2 <= num)
            {
                if (imageEncoders[num2].MimeType == mimeType)
                {
                    break;
                }
                num2++;
                continue;
            }
            return null;
        }
        return imageEncoders[num2];
    }
}
