using Moq;
using Web.Services.Interfaces;

namespace WebTest;

public class BillOcrTests
{
    private const string ExpectedBillOcrString =
        "\"TEŞEKKÜRLER\\r\\nGUNEYDOĞU TEKS. GIDA INS SAN. LTD.STI.\\r\\nORNEKTEPE MAH.ETIBANK CAD.SARAY APT.\\r\\nN:43-1 BEYOĞLU/ISTANBUL\\r\\nGÜNEŞLİ V.D. 4350078928 V. NO.\\r\\nTARIH : 26.08.2020\\r\\nSAAT : 15:27\\r\\nFİŞ NO : 0082 15:27\\r\\n54491250\\r\\n2 ADx 2,75\\r\\nCC.COCA COLA CAM 200 08 *5,50\\r\\n2701084\\r\\n1,566 KGx 1,99\\r\\nMANAV DOMATES PETEME *3,32\\r\\n2701076\\r\\n0,358 KGx 4,99\\r\\nMANAV BIBER CARLISTO 08 *1,79\\r\\n4\\r\\nEKMEK CIFTLI 01 *1,25\\r\\nTOPKDV *0,80\\r\\nTOPLAM *11,86\\r\\nNAKİT *20,00\\r\\nKDV KDV TUTARI KDV'LI TOPLAM\\r\\n01 *0,01 *1,25\\r\\n08 *0,79 *10,61\\r\\nKASİYER : SUPERVISOR\\r\\n00 0001/020/000084/1//82/\\r\\nPARA USTÜ *8,14\\r\\nKASİYER: 1\\r\\n2 NO:1330 EKÜ NO:0001\\r\\nMF YAB 15017876\\r\\n\"";

    private readonly IBillOcrService _billOcrService;

    public BillOcrTests()
    {
        var billOcrMock = new Mock<IBillOcrService>();
        billOcrMock
            .Setup(x => x.GetBillOcrStringAsync())
            .ReturnsAsync(ExpectedBillOcrString);
        _billOcrService = billOcrMock.Object;
    }

    [Fact]
    public async Task BillOcr_GetBillOcrString_ReturnsSuccess()
    {
        var billOcrString = await _billOcrService.GetBillOcrStringAsync();
        Assert.NotNull(billOcrString);
        Assert.Equal(ExpectedBillOcrString, billOcrString);
    }
}