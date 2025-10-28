using System;

namespace ShelfSync.Shared.Entities;

public class LabelConfig
{
    public float LabelWidthInches { get; set; } = 3.0f;
    public float LabelHeightInches { get; set; } = 1.0f;
    public float TopMargin { get; set; } = 8f;
    public float LeftMargin { get; set; } = 8f;
    public float RightMargin { get; set; } = 8f;
    public float BottomMargin { get; set; } = 8f;
    public float BarcodeFontSize { get; set; } = 32f;
    public float TextFontSize { get; set; } = 9f;
    public float BarcodeHeightScale { get; set; } = 1.3f;
}
