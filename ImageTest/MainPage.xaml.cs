using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ImageTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<string> _logs = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();

            Logs.ItemsSource = _logs;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            const string sources = @"
/az/hprichbg/rb/SummerGlory_JA-JP10279441095
/az/hprichbg/rb/MarshallPoint_EN-US8972162631
/az/hprichbg/rb/HiroshimaCrane_JA-JP11357784772
/az/hprichbg/rb/PortAntonio_JA-JP9246692740
/az/hprichbg/rb/LovePark_EN-US10739395628
/az/hprichbg/rb/FireweedForest_EN-CA11703790619
/az/hprichbg/rb/FinnichGlen_EN-GB11900101807
/az/hprichbg/rb/FringeFireworks_JA-JP11044516483
/az/hprichbg/rb/BadlandsCycle_EN-US12588823059
/az/hprichbg/rb/NebutaFloat_EN-US10266438691
/az/hprichbg/rb/MtlFireworks_EN-CA11326419961
/az/hprichbg/rb/SwissSuspension_EN-US8560310773
/az/hprichbg/rb/LeuchtfeuerRotesKliff_DE-DE9045826870
/az/hprichbg/rb/ParkRangerIsmael_EN-US8783805449
/az/hprichbg/rb/ChildrenPlaying_EN-US9664693753
/az/hprichbg/rb/T19Krishna_EN-US11510458805
/az/hprichbg/rb/NamgyalTsemo_EN-IN12331885817
/az/hprichbg/rb/WinskillStones_ROW11166714526
/az/hprichbg/rb/FWsumida_JA-JP14151271156
/az/hprichbg/rb/FairSeason_EN-AU8821036782
/az/hprichbg/rb/SuperBlueBloodMoon_EN-US11881086623
/az/hprichbg/rb/Halsbandsittich_DE-DE7608325277
/az/hprichbg/rb/LetchworthSP_DE-DE14482052774
/az/hprichbg/rb/HomerWatercolor_EN-US11392693224
/az/hprichbg/rb/Valparai_EN-IN8520364320
/az/hprichbg/rb/SouthwoldBeach_EN-GB12645299269
/az/hprichbg/rb/FlamingoCousins_EN-US13543498875
/az/hprichbg/rb/EmeraldLakePeaks_ROW9424944943
/az/hprichbg/rb/MoriBuilding_EN-US5143587469
/az/hprichbg/rb/VaranasiCandles_EN-US12230572751
/az/hprichbg/rb/CometMoth_EN-US9387578049
/az/hprichbg/rb/Apollo15Composite_EN-US10046867284
/az/hprichbg/rb/MumbaiMonsoon_EN-IN9639164493
/az/hprichbg/rb/DresdenKunsthof_DE-DE11486364210
/az/hprichbg/rb/ComicFans_EN-US10352835982
/az/hprichbg/rb/TijucaForest_ROW13498718760
/az/hprichbg/rb/MandelaMonument_EN-US8903823453
/az/hprichbg/rb/StinkBugSmiley_EN-US7711508774
/az/hprichbg/rb/UrbanLight_EN-US6248743710
/az/hprichbg/rb/WCFansChamps_FR-FR10181518982
/az/hprichbg/rb/SoccerStadium_EN-US11597501512
/az/hprichbg/rb/RathaYatra_EN-IN10168581752
/az/hprichbg/rb/FlagsBastilleDay_FR-FR11262878201
/az/hprichbg/rb/BlueShark_EN-US12265881842
/az/hprichbg/rb/RockOfGibraltar_EN-GB10156341114
/az/hprichbg/rb/GordesLavender_EN-US10563684536
/az/hprichbg/rb/zhenghe_ZH-CN9628081460
/az/hprichbg/rb/PuffinWales_EN-GB12757555133
/az/hprichbg/rb/BigBenChimed_EN-US9959774618
/az/hprichbg/rb/RCMPStampede_EN-CA5774727755
/az/hprichbg/rb/BooteRurstausee_DE-DE9221005075
/az/hprichbg/rb/FremontPeak_EN-US8617183007
/az/hprichbg/rb/MacawsKissing_ROW11419590512
/az/hprichbg/rb/Gauchos_EN-US9437338004
/az/hprichbg/rb/Flamenco_EN-US13472533209
/az/hprichbg/rb/YukonWatershed_ROW11752412278
/az/hprichbg/rb/WestminsterPride_EN-GB11603893615
/az/hprichbg/rb/TanaKazari_JA-JP10589347436
/az/hprichbg/rb/Peloton_EN-US7472605035
/az/hprichbg/rb/KissingPandas_EN-AU8854909213
/az/hprichbg/rb/NHSBirthday_EN-GB10548570992
/az/hprichbg/rb/Pygmy3Toed_EN-US11340370698
/az/hprichbg/rb/ButtermereLake_EN-GB9719712376
/az/hprichbg/rb/MNFireworks_EN-US9611301754
/az/hprichbg/rb/SpottedDeer_EN-IN10736205241
/az/hprichbg/rb/GeorgeMeade_EN-US9381168835
/az/hprichbg/rb/TurtleIndianOcean_EN-AU10313307709
/az/hprichbg/rb/WimbledonHats_EN-GB11285333407
/az/hprichbg/rb/EtaAquarids_EN-US10944490288
/az/hprichbg/rb/HONKONG_ZH-CN11971924406
/az/hprichbg/rb/CMCKolkata_EN-IN15214439103
/az/hprichbg/rb/TorontoFireworks_EN-CA8729545760
/az/hprichbg/rb/HetzlesSonne_DE-DE8994146341
/az/hprichbg/rb/SeattleGreatWheel_EN-US12789575669
/az/hprichbg/rb/Chinowa_JA-JP10611091419
/az/hprichbg/rb/CabourgRomanticFilm_FR-FR6819634320
/az/hprichbg/rb/MeteorCrater_JA-JP9993563603
/az/hprichbg/rb/AuroraPhotographer_EN-US10752129713
/az/hprichbg/rb/CompositeBeach_EN-US10477241178
/az/hprichbg/rb/OntCranes_FR-CA8789580709
/az/hprichbg/rb/MorondavaBaobab_EN-US11363642614
/az/hprichbg/rb/MODIS_EN-US13699515239
/az/hprichbg/rb/ConcreteDinosaurs_PT-BR9038296644
/az/hprichbg/rb/HansOttoTheater_DE-DE7941948001
/az/hprichbg/rb/BeachSoccerBoys_JA-JP12914801215
/az/hprichbg/rb/MinneapolisPride_EN-US8577554439
/az/hprichbg/rb/Europa_EN-US12048620642
/az/hprichbg/rb/CaruaruClayDolls_PT-BR13559051231
/az/hprichbg/rb/DogWork_EN-US10032511594
/az/hprichbg/rb/lotus_ZH-CN12081917194
/az/hprichbg/rb/ArtDecoAndernos_FR-FR7481438350
/az/hprichbg/rb/ReichenauSommer_DE-DE10444104319
/az/hprichbg/rb/RedRocksYoga_EN-US9887175850
/az/hprichbg/rb/WorldRefugeeDay_EN-US5421237644
/az/hprichbg/rb/BulbulBranch_EN-IN9094206201
/az/hprichbg/rb/CypressPygmyOwl_JA-JP12586622672
/az/hprichbg/rb/AlvinAileyRevelations_EN-US9442717509
/az/hprichbg/rb/DUAN_ZH-CN9451316695
/az/hprichbg/rb/SanMiguelFishing_EN-US10852654681
/az/hprichbg/rb/BrazilStreetFlag_PT-BR10888488897";

            var array = sources.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            ListView.ItemsSource = array.Select(temp => "https://wpdn.bohan.co" + temp + "_1920x1080.jpg");
        }

        private void OriginImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Debug.WriteLine(e.ErrorMessage);

            _logs.Add(e.ErrorMessage);
        }

        private void ImageEx_ImageExFailed(object sender, ImageExFailedEventArgs e)
        {
            Debug.WriteLine(e.ErrorMessage);

            _logs.Add(e.ErrorMessage);
        }

        private async void ClearCacheButton_Click(object sender, RoutedEventArgs e)
        {
            await ImageCache.Instance.ClearAsync();

            await new MessageDialog("done").ShowAsync();
        }
    }
}