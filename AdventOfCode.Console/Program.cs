﻿namespace AdventOfCode.Console
{
    using System;
    using System.Linq;
    using System.Text;

    using AdventOfCode.Console.Properties;
    using AdventOfCode.CubicleMaze;
    using AdventOfCode.Day14;
    using AdventOfCode.Day142015;
    using AdventOfCode.Day15;
    using AdventOfCode.Day152015;
    using AdventOfCode.Day16;
    using AdventOfCode.Day162015;
    using AdventOfCode.Day172015;
    using AdventOfCode.Day18;
    using AdventOfCode.Day182015;
    using AdventOfCode.Day19;
    using AdventOfCode.Day192015;
    using AdventOfCode.Day20;
    using AdventOfCode.Day202015;
    using AdventOfCode.Properties;

    using Xunit.Sdk;

    class Program
    {
        static string LookAndSay(string number)
        {
            StringBuilder result = new StringBuilder();

            char repeat = number[0];
            number = number.Substring(1, number.Length - 1) + " ";
            int times = 1;

            foreach (char actual in number)
            {
                if (actual != repeat)
                {
                    result.Append(Convert.ToString(times) + repeat);
                    times = 1;
                    repeat = actual;
                }
                else
                {
                    times += 1;
                }
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            //var otp = new OneTimePad();

            //Console.WriteLine(otp.GetThisKey(65, "jlmsuwbz", 2016));
            ////Console.WriteLine(otp.GetThisKey(64, "abc"));
            //Console.ReadKey();

            //ChineseRemainder.Execute();
            //Console.ReadLine();

            //var rdo = new ReindeerOlympics();
            //rdo.CalculateDistancesAtTime(2503, Resources.RdsIn);
            //Console.ReadKey();

            //var sfhp = new ScienceForHungryPeople();
            //sfhp.Setup(Resources.SFHPIn);
            //Console.WriteLine("Getting all possibilities...");
            //var allPossible = sfhp.GetAllPossibleRecipes();
            //Console.WriteLine($"Found all possibilities. Count: {allPossible.Count}");
            //Console.WriteLine("Finding optimal configuration...");
            //var best = sfhp.GetBestRecipe(allPossible);
            //Console.WriteLine("Best found. Recipe:");
            //foreach (var ingred in best)
            //{
            //    Console.WriteLine($"{ingred.Key.Name}: {ingred.Value}");
            //}
            //var total = sfhp.GetTotalVal(best);

            //Console.WriteLine($"Highest total: {total}");

            //Console.WriteLine();
            //Console.WriteLine("Now finding optimal 500-calorie configuration...");
            //var bestWith500Cals = sfhp.GetBestRecipeWithRightCalories(allPossible, 500);
            //Console.WriteLine("Best found. Recipe:");
            //foreach (var ingred in bestWith500Cals)
            //{
            //    Console.WriteLine($"{ingred.Key.Name}: {ingred.Value}");
            //}
            //var newTotal = sfhp.GetTotalVal(bestWith500Cals);

            //Console.WriteLine($"Highest total: {newTotal}");

            //Console.ReadKey();

            //var was = new WhichAuntSue();
            //Console.WriteLine(was.FindAunt(Resources.AuntsIn));
            //Console.ReadKey();

            //var nstatm = new NoSuchThingAsTooMuch();
            //var combos = nstatm.FindAllCombinationsOfContainersToFit(150);
            //Console.WriteLine($"Count of combinations: {combos.Count}");
            //var minCombo = combos.Where(m => m.Count == combos.Min(j => j.Count));
            //Console.WriteLine($"Min containers: {combos.Min(c => c.Count)}");
            ////foreach (var cont in minCombo)
            ////{
            ////    Console.Write($"{cont},");
            ////}
            //Console.WriteLine($"Number of combos of min count: {minCombo.Count()}");
            ////Console.ReadKey();

            //var al = new AnimatedLights();
            //al.Setup(Resources.LightsIn);
            //Console.WriteLine($"Lights lit after 100 iterations: {al.Part2(100)}");
            //Console.ReadKey();

            //var mg = new MedicineGenerator();
            ////var pos = mg.GetNumberOfDistinctTransformations(Resources.MedIn);
            ////Console.WriteLine($"Distinct permutations: {pos}");
            //var minStepsToMakeMoleculeFromE = mg.GetMinStepsFrom("e", Resources.MedIn);
            //Console.WriteLine($"STEPS: {minStepsToMakeMoleculeFromE}");
            //Console.ReadKey();

            //var ieih = new InfiniteElvesInfiniteHouses();
            //ieih.GetLowestHouseNumberToGetAtLeastThisManyPresents(36000000);
            //Console.ReadKey();

            var ir = new IpRanges();

            ir.RemoveInvalidRanges(Resources.IpRangesIn);
            Console.WriteLine($"MIN: {ir.GetMin()}");

            //var lar = new LikeARouge();
            //lar.Setup();
            //Console.WriteLine($"Safe tiles: {lar.GetNumberOfSafeTiles()}");

            //var we = new WhiteElephant(3004953);
            //we.Solve();

            //var dc = new DragonChecksum();
            //var output = dc.GenRandomData("11100010111110100", 35651584);
            ////Console.WriteLine($"OUTPUT DATA: {output} (length {output.Length})");
            //Console.WriteLine();
            //var checksum = dc.GenChecksum(output);
            //Console.WriteLine($"CHECKSUM: {checksum} (length {checksum.Length})");
            //Console.ReadKey();

            //            var tie = new TimingIsEverything();
            //            tie.Setup(Resources.TimingIsEverthingIn);
            ////            tie.Setup(@"Disc #1 has 5 positions; at time=0, it is at position 4.
            ////Disc #2 has 2 positions; at time=0, it is at position 1.");
            //            Console.WriteLine();
            //            Console.WriteLine($"GOT IT AT TIME: {tie.PleaseWork()}");
            //            Console.WriteLine();
            //            Console.WriteLine($"RESETTING AND ADDING A NEW DISK");
            //            tie.SecondSetup(11, 0);
            //            Console.WriteLine();
            //            Console.WriteLine($"GOT IT AT TIME: {tie.PleaseWork()}");
            //            Console.ReadKey();
            //var cm = new Puzzle();
            //var size = 50;
            //cm.Setup(size, 1352);

            //var pathLen = cm.GetPathLength();


            //if (pathLen == 0 && size < 1000)
            //{
            //    while (pathLen == 0)
            //    {
            //        size += 5;
            //        cm = new Puzzle();
            //        cm.Setup(size, 1352);

            //        pathLen = cm.GetPathLength();
            //    }
            //}

            //Console.WriteLine("Path length: " + pathLen);
            //Console.WriteLine();

            //Console.WriteLine("PART 2");
            //Console.WriteLine();

            //var numberOfLocationsReached = cm.GetNumberOfLocationsWithinSteps(50, 1352);
            //Console.WriteLine();
            //Console.WriteLine($"Can reach {numberOfLocationsReached} locations (other than starting location) within 50 steps");

            //Console.ReadKey();

            //var lm = new LeonardoMonorail();

            //lm.Execute(Resources.LeonardoMonorailInput);

            //Console.WriteLine($"Val at register A: {lm.Registers["a"]}");
            //Console.ReadKey();

            //var bb = new BalanceBots();

            //bb.Setup(Resources.BalanceBotsInput);

            //Console.WriteLine(bb.Execute());
            //Console.WriteLine($"Multiplied a chip in outputs 0, 1 and 2: {bb.GetMultiplyRes()}");
            //Console.ReadKey();

            //var eic = new ExplosivesInCyberspace();

            //var outString = eic.DecompressAndRecurse(eicIn, true);
            //Console.WriteLine(outString.Length);

            //Console.ReadLine();

            //var tfa = new TwoFactorAuth(6, 50);

            //tfa.Generate();

            //var hm = new DinnerTableHappinessOptimizer();

            //var opt = hm.GetOptimalDeltaHappiness(hmInput);

            //Console.WriteLine($"Optimal: {opt}");
            //Console.ReadKey();
        }



        private static string eicIn = @"(22x11)(3x5)ICQ(9x5)IYUPTHPKX(127x2)(41x6)(16x9)SIUZCKMFZFXKUYTQ(13x3)YBCVHJPPFAONV(10x14)BTRWBQRUHA(57x4)(12x15)ZUMPYOEOOBFW(5x11)YNLIJ(8x9)GBQFPTOH(9x3)GPFCSAPZD(29x4)(5x15)EFWZC(12x4)(7x5)ERKGRCO(145x10)(4x6)QPQJ(36x5)AXJPYRPXJNUYIMCCYQIFAHELCWHVENPFFUDA(68x9)(14x15)EMRKZDNYNDIJHZ(5x12)CKQKZ(17x8)NBRXQIMACOZLIPEMC(8x7)BBLDSICW(1x11)M(7x11)FLYGTGJ(78x11)(9x6)DHGXUSOKT(22x8)(1x7)X(10x5)KRJUANGDCJ(1x6)V(4x12)VCOH(14x1)WDBRKJHMCVSNVI(9x6)YUGDHWETA(93x12)(8x15)(3x7)SVK(6x13)(1x7)Y(60x10)(15x15)LKKAVGRGFZABIBU(32x3)YOFMNLNRJRINIZCCYLKLUOFWVWXFDXQR(28x15)(22x6)(1x15)X(2x8)WT(3x7)SGS(9154x10)(3069x9)(1176x8)(349x15)(6x10)FHKHUN(50x12)(5x6)IEEKH(4x2)DHEG(1x4)O(18x14)YTXWGQAJVTUHRZHTPY(55x8)(48x10)(1x3)I(3x12)JRS(1x9)F(20x12)HXVRCJMSGSCGSBLAUVJJ(134x14)(57x1)(7x7)SDSUJPL(2x12)JM(3x9)YCW(7x2)ZWLPPDY(11x3)GMQBJDOWHXQ(35x11)(5x9)IIEIX(1x8)S(12x15)AQOUQNNNQMFD(22x12)OTYVCAUYJACBXRRQCQHXNM(71x1)(7x7)WOHKEXX(5x10)LZMIE(2x7)AY(35x4)(17x8)DOPOULZLKOXMLSVNU(7x5)KEKYTGL(2x14)LQ(480x2)(276x15)(197x5)(27x10)JSPSRSOZEKYBVYQLDOHBLZYSXAW(21x4)UMMABURKONXVVCIDVULSI(8x5)VMBUJKXG(16x2)IVRUXQSEFOLCTKOY(94x10)UNWKXWVAGWRWETXKDOZVMUUKDPPQFTEKBEROINVJMTPTJTATLUQBYCRLAXJOSAPOJHPVUSXDIWYHGCQNFHJQYOQEMDDMLJ(66x7)(12x10)QPJPHFNJQUMU(2x3)BZ(26x11)YFDFOVWPPMHHXJNAJOVQAUUFUZ(1x14)S(25x4)ZESZWBTXMAWSETLVMGABELTYE(42x11)(36x6)(5x10)DYNEK(18x10)MRWEUKMJFYMLZMJAJD(9x5)PWGVXGHOB(95x10)(24x4)(7x7)EOWRNFA(7x8)GDKNIDU(15x12)EOWLMVTPSDDVVUL(19x3)JFUVRUIVSIHLLQYNSNO(6x8)PAHGHQ(1x13)S(159x15)(140x8)(11x11)XNRUJBJSSJM(72x5)(8x1)NXVJJGVN(22x6)AFBQMOKFGGBTCJFSWXUOBO(25x9)NKOREPRXKIDGCYYDULYUEQPCZ(1x11)F(13x3)KORAZGCZLLHNB(11x13)PVJREGERBSJ(7x5)MKPHSGS(150x5)(103x2)(7x12)(2x4)NT(38x9)(31x10)PUWLXNBDGQCFTZATASBYXCMPPFZJWAR(31x7)(7x1)RBHEBLO(12x10)MENDHXBKZDGR(4x3)JVTO(33x15)(5x8)NDPEL(5x11)BENTA(6x11)MVMDHP(614x9)(6x2)RUCNIE(510x12)(278x8)(58x8)(12x4)KEXDSMQTLFWZ(8x4)BFQCNUJI(21x9)NZBSKNFOWBUDIFGLDXYHA(22x2)HVIGUZSLXDWDXDRCVZPEJC(24x1)MVIDEIQLVSELKAUUHHPGTSNF(17x7)PILQQSWRTXVFCXXMU(125x10)(2x11)YR(71x2)TZVUISFVWFEZQCQBEXNRSRAIJDQAHZNKWGDSWBZGJAPZBNFWCXESKZQJGAUXSHHCBLJSYQY(13x10)VSEOIPEVJQMRV(3x1)DSJ(6x15)CREQOP(6x13)CTRYFR(191x6)(10x14)PHRXDMQNJN(78x12)(4x13)QAIT(32x10)ICKTMMEOAHFGSISYAWQTQFUWWRKCVLHW(6x12)TDSTMP(3x6)SJU(4x3)WCGJ(51x7)(7x11)QSJERFT(11x6)FOHQRGIGNHD(2x2)FO(9x8)FVOSYSGOQ(20x7)RXXISOFDENOWQDLGGWGS(1x2)Q(9x11)QFQVFWUKV(79x3)(4x3)JESH(42x5)(4x10)HLPY(25x10)UOJHBIMVYNSCNYAVXVZFDKFUD(1x12)W(9x13)SWEHSNTYH(365x3)(358x4)(5x8)PSVSY(53x14)(39x13)(11x1)BZVYURTWDXO(8x15)IFLFXMTW(3x7)OWX(2x3)EY(141x2)(55x3)(3x3)GFW(24x3)FAEVVTFKPGLONEZAPTIFWKAY(1x11)A(4x10)LRSZ(37x12)(2x15)MB(2x4)QF(4x3)QTQD(7x14)ITPBCPO(22x15)(1x8)P(10x2)OPYYYSMAZD(2x6)DR(121x4)(24x10)ZDFXFCGIZSAEEISWYLIWOSHV(2x14)IE(75x15)(17x5)JNPVHILACIRBRVFOV(13x8)LKESWWFWMREZR(4x15)FMVW(17x4)UNAKDRSCVCBWOJUAG(7x4)(1x14)F(884x10)(11x13)UIJLAOENTIO(525x6)(198x10)(3x12)VVK(10x13)CDFZVNZRXN(89x14)(29x4)RGMMJYVTUSTNURKJUGAROSPANJDRP(5x4)DDMAL(4x12)ZUFB(13x1)FRZPWDKILEKPW(9x15)HQRFMVQKA(28x2)(12x15)UYMVCFZGVAPZ(4x3)VCFF(35x15)(9x3)SHOEBNTLG(6x2)OEZGQV(5x1)PMPMS(12x8)CJOKQADNVIFP(193x9)(49x13)(11x15)YSUAHEFQFGE(24x13)BFPKROZXMUJAPOPTDUAVPDYA(5x4)JCKOZ(10x7)AKOWVCYMBR(5x1)QVUIE(95x8)(21x9)SPAZDZXRAVUPETVJEHBJT(21x12)PIYCMQYDJNXTWUWLQDMBU(13x5)QYVTFYYKTRFYJ(4x11)UHOG(5x11)YKDQT(95x5)(6x5)SESOZW(6x5)JVUMCD(53x7)(28x1)NPAWZKLFYJRJTBCBORTTCEKCLHNS(12x13)FGHPQQNJCBOH(2x9)YO(2x7)BC(308x6)(32x15)ETOWFJPXZOGWFGJARLBUUVEAFONJOSLW(150x1)(13x14)(7x15)QQXHWPZ(12x3)XXFTSKLVBLNM(2x14)XD(98x5)(10x2)IVITAAHEJC(28x4)NFTTQKTZISTINCJCUPOJRTGMIUDD(13x6)PAEWLFDAREAGA(4x6)SUDT(14x7)UOFNKCCWRMTNKZ(45x9)(9x10)(4x3)YECM(6x3)KKZJLO(13x2)VMSRHSEOJOYII(55x7)(1x4)S(8x3)TYXKBZRQ(18x3)(12x9)VHSESLORJRVL(7x9)DQDGRBE(13x5)ZIZVIPWCIQEMN(3279x13)(58x9)(16x4)AZKZJLWQNHTHGOHO(30x2)ZYSTCIOTDHPKDSMCVNKTZFNYPONYFX(202x6)(194x15)(6x1)PUSNVA(175x15)(14x10)FSZUQBSQQNHKAK(52x8)(39x2)XVEZNBPBBPMDQTHCCGYIJSROSVXTDGCWKQWPLZZ(1x11)U(83x1)(6x5)AUDVOG(7x12)OHICDSF(13x8)NOZKYWMCCDFGM(14x14)AQBYBKHLUTOUUK(13x2)BOUZNPYNVBDSP(2x6)OF(1027x1)(457x1)(151x8)(67x11)(9x7)QWWUQUGBT(16x7)IPKDWITLAMCEHCEE(13x1)DCFKDXBDNFYQF(6x10)RJOSEW(71x4)(1x1)M(5x5)WNKRF(4x7)ALBH(15x14)MKLZDQFGXSAXUFN(18x4)DJKPPRYXFQJZFOKKSS(118x1)(3x11)MTZ(43x12)(22x13)DWYLTBXHWWHFLFPYTMMVAM(9x8)GNPYYJYIV(13x15)TICBWPCYTKQAU(12x12)(6x11)NMPBRP(14x8)NYXDKVLLHESFHE(72x5)(13x10)NYANWHLDADTMX(11x2)CITDQLSHSAW(13x9)(8x5)ZCPOEXBY(3x13)FSP(2x7)OI(89x11)(42x2)(13x2)DXESJUVOVEHKV(1x5)I(3x12)LLZ(3x7)RTR(21x11)(15x5)XCOLHZFLTHCUOQP(8x7)(2x14)OS(339x5)(59x14)(16x1)(10x8)XQSHKLDBFE(8x7)JGLXFOUP(18x8)CTLEBSYBUFGZQVCGRA(9x3)TQNDSDMOT(30x10)PRJKGFTVJCLUKRINWDKSUJEGYKWAUU(129x10)(9x4)ZJQMCNHEP(45x9)(2x4)XF(2x9)NG(24x15)ZMJKSMDTQNKLAPIMOUWMGJSY(23x7)(3x6)QJL(3x4)RBA(1x14)G(29x5)JNIDQYEIHNLBMSBXJECOZQITUOWBA(78x12)(33x8)(5x11)IOMKY(7x9)XHFJSYP(5x5)WEITI(32x12)(4x14)GAHE(15x15)ZAESAKNMLLDJPYO(9x4)(4x6)KXSL(186x5)(13x12)(8x2)(3x5)EEN(7x10)RUZFOWY(145x13)(5x14)CPDKP(4x11)PZVC(31x8)(17x12)MGYDIPAMCZNUMNJQW(2x5)XX(81x1)(19x12)GIIRQYWSJVTZYEPEJDV(2x14)LK(41x4)OCIZXGSYSGIMQYTJADPPCEVKHLBHWHNBWJHNYOYLI(5x8)AABDE(666x6)(177x2)(2x13)ZM(43x14)(37x4)(4x12)JEGE(12x2)TRFTZDTQOTQY(3x14)DEK(112x7)(2x8)UK(18x1)KJLOHGBGYTHKFSCDKV(11x10)UPGSRAHGSPG(5x11)SXTHS(46x7)(6x8)ZSCFAE(8x3)BBYLDLEE(8x2)HESZAEOF(4x5)YDZB(302x7)(85x10)(3x8)SGQ(4x13)ARMT(19x9)CZXVWXTAWXFMQIDLEMX(27x10)(1x6)L(6x4)WHPCVR(5x4)CVXIJ(3x3)MCU(129x4)(10x13)JVYHZXZRZH(23x7)(1x3)Q(3x3)HTC(3x10)MCT(11x15)(5x11)LXXWV(59x8)(4x7)BFOS(8x9)QJNBTALP(17x1)VRADQJAVMSJJEDSYW(8x10)VCUWMSUG(3x8)ZUX(6x1)PFSFHN(48x10)(42x4)(22x12)ILMDCUNYBDGVPRAYZEOWGE(1x3)O(2x9)FW(160x2)(6x1)(1x9)F(128x4)(14x14)JTUVRBJUROWHBL(29x9)(13x6)IXLVAFWLGQGIS(4x10)IEQX(11x10)(5x11)YJRSN(47x10)(1x1)V(2x6)CZ(4x6)VQCT(8x1)BVYHIFQS(7x6)CYKHWLP(9x5)BIXENRKXL(1x3)A(1290x2)(5x4)SDQSC(467x8)(131x6)(23x4)(9x15)UHIBXLYPH(3x5)FHO(29x5)(2x12)XF(6x2)TOEUOL(5x7)XQPGR(54x8)(4x8)ADEM(18x7)WZZGFJKVVIXGBCUZJN(4x7)DFYQ(7x5)GWZECTZ(2x5)ZK(40x9)(24x8)(1x5)W(2x5)CX(5x14)NZCXG(4x12)UVOM(6x13)TVTSEE(191x15)(111x3)(35x15)UNBVMZXNMJMBANNULOOAQJVZGHXPXTIMSJD(3x3)IPT(10x2)TUEYZGJFUZ(13x15)OYJACRMRRSYDK(19x9)FNWIPNRIJXSEIZZPTVL(14x8)(9x8)NMEKAAQIK(47x4)(34x9)BXAJCWUFTLYPIRUNSGEQIPNNECIQSTAKKO(2x5)XH(66x8)(19x11)JBOHWGMTYXYLHIEQGYV(17x15)IJKQKBRQCKELHYEEQ(10x4)VCTJEHTMRR(799x3)(17x12)CECLCYLKHNNNRJORS(55x12)(35x9)(13x10)RBUYOHSLZBLNB(9x12)GOMTMSBGH(8x15)JABHESJU(235x14)(49x2)(13x12)POCOOMCDRPBDD(3x14)UUB(2x3)HH(1x6)T(2x5)KP(33x9)(2x11)XZ(18x15)MGBLMUAUUJJNXHTXZO(51x3)(1x12)B(10x13)EESGVVXION(4x7)HDGF(2x3)JJ(6x3)RHVHZW(1x2)V(72x9)(8x3)KRCPSBOZ(3x15)ORP(17x13)RRMSHJOYWOYDYPJFP(1x1)V(14x5)QBTFBGVPZJVQEU(169x10)(16x14)FMBBCEUCNVKPRSIY(45x15)(9x5)XSRYXSPJF(25x4)ROPRMIIHKABTKLLTZUHMPJEZG(87x10)(14x6)QPJVAXCHYWTTQP(8x4)STYZCSAM(5x10)OFTCD(28x11)VXFYZVCMFMXBRGRJXDQRQCIBYWOT(2x10)XR(285x15)(124x3)(5x8)YEGCN(32x8)CPISZJHMTAYEILGEKVESPNBNRVZYVKBQ(34x13)EGASBNYPSJUHFMHPOQBNZNSTQKEWKXPTAG(28x11)VYPAYPUAAURHYLQIQKMLFCTRAVUA(71x7)(2x12)KP(3x6)BGT(12x7)NRADLHJTEXSA(18x7)CCBIEQMPCZRULHIGWK(7x10)CWZOLXX(53x15)(2x3)NH(5x2)JGMMC(2x3)GG(12x5)DVBMMKUAPRYW(6x2)LDZRUL(11x7)UISRTGWZGBA(1441x12)(205x5)(198x1)(112x15)(12x9)(7x9)AUFRDTR(25x2)(6x8)NFQXPE(8x13)UBIQERPU(1x14)S(50x2)(36x13)FCHZSFHMGANOGOUQVLJKOHLDWTMPFMNSRIEE(2x8)TB(12x12)TRFNONQMYBIP(52x12)(11x1)(5x10)WWKAS(28x14)(15x2)CMWTIEXKMRAPKLV(2x3)SE(134x1)(44x8)(8x5)IVGODFUS(16x13)BASOECHOINZYNNMD(2x15)FC(54x11)(29x7)(22x15)FVODZGCRBBMBYOWCIBMVSN(4x14)PJDW(3x10)YDA(5x10)BAJUZ(7x3)(1x14)N(433x15)(425x12)(94x3)(13x11)(7x14)YYITBHX(30x2)OBWPJEYZYQSWDUDLIUCZNZKAPHAQFJ(31x10)(7x5)JHTOXMH(13x5)RMLWZHDTWOUEB(107x5)(10x12)NZMVIUWXEI(15x5)(9x13)KKFXSAMBX(14x3)QWXFSSFJFDTGOT(7x3)YDOEMMV(30x13)(24x2)PXHELXXFAKACDZHBZGNBSUVU(2x11)WF(184x10)(57x7)(22x6)FSFWZBMGYAEZGMWZQTGGMU(15x2)QOTUZLMACRVFWDV(3x9)KIE(9x11)XMVQKMEPC(55x11)(1x13)G(1x14)Y(2x10)JU(27x3)PYBCBHWYJWJNMFZRIMOLKIGGQED(38x2)(11x1)QHKHBHSZMSV(1x12)P(9x3)NBULTVPAG(5x13)LTLHD(628x11)(1x10)C(589x14)(112x10)(1x2)I(22x4)RGDAVMUUEPYFVXXXYOPPNF(17x3)JRMWVCDJHYWFTDGHY(31x11)IMHJJDPKDSWOEBXGUWXYCOXKNIFDBWE(11x4)(6x1)VOJPYT(11x15)(6x8)IEFWPJ(177x4)(63x3)(26x6)FVNYFOSLLUCTIWQHUIAPLLWZBT(12x10)SRODVSMCVDND(7x4)VQMNEUI(100x12)(7x6)NYRSJAI(31x1)LZHAUWPLWJXPQPCPJNQFSTDMACSTPDR(2x13)MF(36x13)ZFFVXRNWMDPDQPSKSRXEUCAXSLOWTSBLPKJY(121x12)(67x6)(7x10)ORAJOEU(20x11)UGTSPNVTPVARWVQLCASL(14x2)TGSWVFJASSRHBL(2x6)GJ(18x15)UTXXOGUWTWGKPVAVUJ(17x6)(11x5)YHLQNVHWBHY(131x3)(9x8)GEJPUPYNK(13x13)VHELEYMCMPASV(68x15)(5x11)UIJJM(3x10)GKW(19x3)FLZJIQDVHVDUQAGCDER(3x5)AVO(9x13)RUVFUSPGU(16x3)RCSWCVDROBDUNFZT(18x4)KKGUBTFVVNXBCHMHJB(5x14)KOBGU(1330x12)(760x9)(73x7)(67x3)(12x11)AOIQYAVPWCCK(7x3)(2x1)EM(30x2)NAFGRGXWIHNGVSFBPDFPSNWBOCLZEG(246x3)(84x10)(7x6)ARXWZED(65x14)(19x7)JOANFDGLJFRIPTBODXH(10x8)QGVAUQRWRT(4x14)OWDF(8x11)WZBAOFSE(27x2)(21x4)CTNUJPAYYUDWIJRDHCGFA(93x7)(21x3)(5x11)YHJBN(5x1)FNSMH(2x7)LR(53x6)(7x5)KDGLDPD(2x7)OF(22x4)ZDUANVNZXEMGQEUDVNQMNK(1x2)R(10x6)(5x7)ADPQJ(2x3)YM(420x12)(8x11)OZRTLFOE(136x3)(5x8)RGGTC(17x5)ZIZBUMRLXLLGLSCFO(3x4)CDR(37x5)(31x4)EORZSDCKDEPKPNLNTNWZGPFARFEHWBH(46x3)(16x11)BDFBLWNLVUHFHEZS(16x14)KCEELDFXQQWPCKQC(255x14)(76x2)(8x10)ARJSJHNW(1x7)F(7x14)BSQQRIN(11x3)PRXIUVTICTB(19x12)QTCZYASWECYNXMOICBM(16x6)HWFGNOGDXKIAZVEJ(75x9)(36x3)BIIJNXOLTASONLVFEZZDHKHMTKWSTSXUAGYF(1x1)Q(21x5)XQUHREKMFMIFALWIUWGTS(30x6)(17x14)QRGDXBHIIADOCOPNV(1x2)U(28x6)(3x9)NPB(6x8)FYYNBJ(3x10)ZYV(555x13)(159x12)(8x4)(2x15)OT(16x14)BFPHRTHSHNTCWMVO(94x13)(2x5)PV(35x13)(4x4)TLEC(20x9)PXFAFUXKVAFGHMHOBFON(5x7)XNKXK(8x1)(3x8)PRZ(16x1)QPXHKCKIONIWQYRX(15x14)(2x9)KD(3x3)KXC(10x3)KISPBWLEKK(365x9)(112x4)(16x2)LAZNYMGAGIMWHSIH(42x3)ONMLAJLYDYVBHRWJXQAOCIRDZKRTNPUBFLNZNIBMVD(2x13)AH(10x15)(5x9)RHLVU(10x10)(5x4)UOURJ(76x9)(70x8)(18x8)SBLXFWEPITIEZALGDN(13x12)AMATXJMGSOCYB(5x3)OXSKV(2x12)ER(3x8)RRT(157x4)(99x14)(6x15)XMHCMB(35x4)OBBFOQFMLRHSNJBCKWQFZAPWYURPFSQVJVM(17x9)ESHQFHJAZSCGWYVGG(16x11)VFQFDDVZCTBSZOOX(38x4)NJVHVYRULGUNXXLOFBPQAOYYGECLIEVXQKVAWI(1x14)Y(1991x9)(1353x10)(474x9)(7x3)(2x6)KD(124x9)(117x5)(45x9)(10x4)PEWOKCGEWI(22x12)PRYYMTEPGIBALMTTOJFDCJ(35x4)(3x2)RGI(11x1)IKZKCSTHAWC(5x6)JKZGM(19x8)(12x10)TTSYTMTXVSQQ(323x15)(200x2)(28x6)(12x15)KJGXXFFSSLAA(3x12)EFZ(12x9)(7x8)ZLVCZNP(67x3)(5x2)ZSEIN(3x15)VRX(14x1)HMRYHPKBKDBMHS(14x12)NWRUWEPPXIUVES(1x13)P(68x12)(17x4)REXCOUFKZRHTIWQTH(12x8)WYHWEYJONJSS(20x11)PMPDVXSCLOBQRFXBPIGD(11x6)KLZUXCZXCYP(93x5)(73x15)(2x6)XA(20x1)YUAGPDIOAQCZDOINQJEP(10x15)ADYQCNJOWE(16x10)ZJNULEVWXPIBKPMQ(8x7)OWEJLEVV(864x10)(33x10)(14x8)BHIIJFZZJWFVOZ(7x13)(2x3)ZI(210x13)(202x15)(67x2)(3x11)DFX(4x11)LJZT(16x12)SJMFRNOVZHZYPYOC(19x6)KVHJFFUBLGCJFFYQLKP(27x13)KSAJRPVXLPTWQTDHDCURUVRTUWU(82x3)(8x15)WQBJUYEN(13x9)NVXYVNOZIXDOS(19x15)ABRMCYAPGLYFFAVQVJP(3x10)NVS(8x14)QXJJEKNN(2x1)JR(561x2)(213x13)(5x3)RRLFZ(66x15)(3x13)BWL(6x13)TPVGOC(29x14)IRVRVKZRERLIBIJZUPCUJEQKIXYDM(3x10)NWK(2x12)KX(115x9)(20x5)NQMSGIFADJAROBVDRYZV(16x7)GHDIQGFIVBYZXPOQ(1x6)T(55x9)VAMBAYGGKDULFUOZRDUSJGCNJTLKHDLUEPTVCTRCMPTKCCOMKUGBXPO(222x6)(109x2)(11x3)RITEKLEHGLP(10x5)ZQSCCVTRUI(23x5)FUZTMKDOMPHSLSPEEDCEFAI(22x15)VYZKZJSQTJXBHEWBKBSAJZ(12x4)XWCGWTZLAAXP(40x14)XJCYDBXAERPKVTWRIOKILGLUQRUMYAXUBGCTHOPJ(52x14)(11x8)TVLNOWHYSGC(1x6)T(2x13)UM(3x9)VMS(8x3)PJVKGRKE(50x8)(9x13)DKRNISHUW(29x7)(4x14)QUCV(7x14)EUPQTDR(1x1)M(11x7)PXZGYDYDFBX(31x12)(11x11)BMGYSEUMRWT(8x6)(2x12)GW(32x5)(18x11)(6x6)EFWCBG(2x2)JF(2x7)HD(621x11)(2x4)EV(607x8)(90x12)(17x7)XAJHZJBSXUZSPIWUG(61x7)(6x12)(1x5)O(42x15)(1x4)T(2x7)DK(9x12)ZDIRKGQRB(8x15)WNNHVPEX(503x1)(12x7)(7x6)JVAPSMI(86x9)(45x8)(1x14)E(32x6)GRFUWVYLATDVBCPXOHKLOVHZYSGUUJYP(28x12)BJAGISXIMZOJSRLPMEUTIYJWEKMW(124x7)(67x3)(28x3)PJTZGDEUAVDQICPLUVXVTVJTUROK(2x14)LP(11x12)XFJJHQJMWZB(1x13)M(14x13)JKXYFRIDHUZRWG(12x6)KYEVJMUSSVUK(6x12)DTKDSL(242x3)(2x2)HJ(50x4)(6x5)XUIVOZ(1x14)V(4x8)APZW(16x14)HXRYJVUNTZHFWAKS(98x1)(6x14)YZWMLJ(14x11)DIDVCJTRZKYVJR(27x3)OGTHYCRWRMBKXFCVEDFQMCKCIPQ(8x13)LNFWFXYN(12x5)DUJAXBNBWNQK(69x4)(1x11)N(5x12)DROVS(26x8)LBPVCHFZIUJJTKFVDHJYDLVBPD(12x13)UEIKUJEAYAJT(7x13)MIGZAGH(171x3)(7x6)SWSAOJL(24x4)(10x6)TFADCGPRFO(2x14)MI(122x3)(26x7)HQOAUWFWSYKNZPOZZNTAGZXMLU(9x5)LGBRFFSCA(15x8)QAQOIVLDKPZKKZI(5x14)QGOZX(37x15)YPTZXTLQLGKLSZVQUTBQYTTRNKTJWSHPRNPAN(140x4)(1x4)T(25x6)(2x9)SZ(12x5)BDMOLPASNRHH(69x4)(2x13)ES(16x7)ZSNXQMXXYASQGCSK(2x5)TR(9x9)HTFMVOCVW(12x9)JGOKJDUZUSYN(9x12)MUJWHXPXN(7x14)UXRYEYI(3x2)OBG(70x1)(39x2)(8x12)NJBFXFDD(5x14)ORZCE(9x4)BRUWUPCJY(12x5)XTXXAJCPTWYL(1x14)I";

        private static string hmInput = @"Alice would gain 2 happiness units by sitting next to Bob.
Alice would gain 26 happiness units by sitting next to Carol.
Alice would lose 82 happiness units by sitting next to David.
Alice would lose 75 happiness units by sitting next to Eric.
Alice would gain 42 happiness units by sitting next to Frank.
Alice would gain 38 happiness units by sitting next to George.
Alice would gain 39 happiness units by sitting next to Mallory.
Bob would gain 40 happiness units by sitting next to Alice.
Bob would lose 61 happiness units by sitting next to Carol.
Bob would lose 15 happiness units by sitting next to David.
Bob would gain 63 happiness units by sitting next to Eric.
Bob would gain 41 happiness units by sitting next to Frank.
Bob would gain 30 happiness units by sitting next to George.
Bob would gain 87 happiness units by sitting next to Mallory.
Carol would lose 35 happiness units by sitting next to Alice.
Carol would lose 99 happiness units by sitting next to Bob.
Carol would lose 51 happiness units by sitting next to David.
Carol would gain 95 happiness units by sitting next to Eric.
Carol would gain 90 happiness units by sitting next to Frank.
Carol would lose 16 happiness units by sitting next to George.
Carol would gain 94 happiness units by sitting next to Mallory.
David would gain 36 happiness units by sitting next to Alice.
David would lose 18 happiness units by sitting next to Bob.
David would lose 65 happiness units by sitting next to Carol.
David would lose 18 happiness units by sitting next to Eric.
David would lose 22 happiness units by sitting next to Frank.
David would gain 2 happiness units by sitting next to George.
David would gain 42 happiness units by sitting next to Mallory.
Eric would lose 65 happiness units by sitting next to Alice.
Eric would gain 24 happiness units by sitting next to Bob.
Eric would gain 100 happiness units by sitting next to Carol.
Eric would gain 51 happiness units by sitting next to David.
Eric would gain 21 happiness units by sitting next to Frank.
Eric would gain 55 happiness units by sitting next to George.
Eric would lose 44 happiness units by sitting next to Mallory.
Frank would lose 48 happiness units by sitting next to Alice.
Frank would gain 91 happiness units by sitting next to Bob.
Frank would gain 8 happiness units by sitting next to Carol.
Frank would lose 66 happiness units by sitting next to David.
Frank would gain 97 happiness units by sitting next to Eric.
Frank would lose 9 happiness units by sitting next to George.
Frank would lose 92 happiness units by sitting next to Mallory.
George would lose 44 happiness units by sitting next to Alice.
George would lose 25 happiness units by sitting next to Bob.
George would gain 17 happiness units by sitting next to Carol.
George would gain 92 happiness units by sitting next to David.
George would lose 92 happiness units by sitting next to Eric.
George would gain 18 happiness units by sitting next to Frank.
George would gain 97 happiness units by sitting next to Mallory.
Mallory would gain 92 happiness units by sitting next to Alice.
Mallory would lose 96 happiness units by sitting next to Bob.
Mallory would lose 51 happiness units by sitting next to Carol.
Mallory would lose 81 happiness units by sitting next to David.
Mallory would gain 31 happiness units by sitting next to Eric.
Mallory would lose 73 happiness units by sitting next to Frank.
Mallory would lose 89 happiness units by sitting next to George.";

//        static void Main(string[] args)
//        {
//            var abacus = new Abacus();
//
//            var input = "[1,2,3]";
//
//            MatchCollection numbers = Regex.Matches(input, "-{0,1}[0-9]+");
//
//            foreach (Match match in numbers)
//            {
//                Console.WriteLine(match.Value);
//            }
//
//            Console.ReadKey();
//        }

//        static void Main(string[] args)
//        {
//            string num = "3113322113";
//
//            foreach (int i in Enumerable.Range(1, 51))
//            {
//                Console.WriteLine(num);
//                Console.WriteLine(num.Length);
//                num = LookAndSay(num);
//            }
//
//            Console.ReadKey();
//        }

        //static void Main(string[] args)
        //{
        //    var sto = new SecurityThroughObscurity();

        //    List<KeyValuePair<string, int>> decryptedValidRooms = sto.GetDecodedRealRooms(Resources.STOInput).ToList();

        //    decryptedValidRooms.ForEach(kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}"));
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    var bw = new BitwiseCircuit();

        //    bw.FollowInstructions(input);

        //    foreach (var wireSignal in bw.Mappings)
        //    {
        //        Console.WriteLine($"{wireSignal.ThisNodeName}: {wireSignal.EvaluatedValue}");
        //    }

        //    Console.WriteLine("-------");

        //    // var a = bw.Mappings.Single(m => m.ThisNodeName.Trim() == "a");
        //    var b = bw.Mappings.Single(m => m.ThisNodeName.Trim() == "b");

        //    b.Op = Operation.ASSIGN;
        //    b.EvaluatedValue = 956;

        //    bw.Mappings.ForEach(m => m.IsEvaluated = false);

        //    b.IsEvaluated = true;

        //    foreach (var mapping in bw.Mappings)
        //    {
        //        bw.Evaluate(mapping);
        //    }

        //    Console.WriteLine($"A SIGNAL: {bw.Mappings.Single(m => m.ThisNodeName.Trim() == "a").EvaluatedValue.Value}");

        //    Console.ReadKey();
        //}

        static string input = @"af AND ah -> ai
NOT lk -> ll
hz RSHIFT 1 -> is
NOT go -> gp
du OR dt -> dv
x RSHIFT 5 -> aa
at OR az -> ba
eo LSHIFT 15 -> es
ci OR ct -> cu
b RSHIFT 5 -> f
fm OR fn -> fo
NOT ag -> ah
v OR w -> x
g AND i -> j
an LSHIFT 15 -> ar
1 AND cx -> cy
jq AND jw -> jy
iu RSHIFT 5 -> ix
gl AND gm -> go
NOT bw -> bx
jp RSHIFT 3 -> jr
hg AND hh -> hj
bv AND bx -> by
er OR es -> et
kl OR kr -> ks
et RSHIFT 1 -> fm
e AND f -> h
u LSHIFT 1 -> ao
he RSHIFT 1 -> hx
eg AND ei -> ej
bo AND bu -> bw
dz OR ef -> eg
dy RSHIFT 3 -> ea
gl OR gm -> gn
da LSHIFT 1 -> du
au OR av -> aw
gj OR gu -> gv
eu OR fa -> fb
lg OR lm -> ln
e OR f -> g
NOT dm -> dn
NOT l -> m
aq OR ar -> as
gj RSHIFT 5 -> gm
hm AND ho -> hp
ge LSHIFT 15 -> gi
jp RSHIFT 1 -> ki
hg OR hh -> hi
lc LSHIFT 1 -> lw
km OR kn -> ko
eq LSHIFT 1 -> fk
1 AND am -> an
gj RSHIFT 1 -> hc
aj AND al -> am
gj AND gu -> gw
ko AND kq -> kr
ha OR gz -> hb
bn OR by -> bz
iv OR jb -> jc
NOT ac -> ad
bo OR bu -> bv
d AND j -> l
bk LSHIFT 1 -> ce
de OR dk -> dl
dd RSHIFT 1 -> dw
hz AND ik -> im
NOT jd -> je
fo RSHIFT 2 -> fp
hb LSHIFT 1 -> hv
lf RSHIFT 2 -> lg
gj RSHIFT 3 -> gl
ki OR kj -> kk
NOT ak -> al
ld OR le -> lf
ci RSHIFT 3 -> ck
1 AND cc -> cd
NOT kx -> ky
fp OR fv -> fw
ev AND ew -> ey
dt LSHIFT 15 -> dx
NOT ax -> ay
bp AND bq -> bs
NOT ii -> ij
ci AND ct -> cv
iq OR ip -> ir
x RSHIFT 2 -> y
fq OR fr -> fs
bn RSHIFT 5 -> bq
0 -> c
14146 -> b
d OR j -> k
z OR aa -> ab
gf OR ge -> gg
df OR dg -> dh
NOT hj -> hk
NOT di -> dj
fj LSHIFT 15 -> fn
lf RSHIFT 1 -> ly
b AND n -> p
jq OR jw -> jx
gn AND gp -> gq
x RSHIFT 1 -> aq
ex AND ez -> fa
NOT fc -> fd
bj OR bi -> bk
as RSHIFT 5 -> av
hu LSHIFT 15 -> hy
NOT gs -> gt
fs AND fu -> fv
dh AND dj -> dk
bz AND cb -> cc
dy RSHIFT 1 -> er
hc OR hd -> he
fo OR fz -> ga
t OR s -> u
b RSHIFT 2 -> d
NOT jy -> jz
hz RSHIFT 2 -> ia
kk AND kv -> kx
ga AND gc -> gd
fl LSHIFT 1 -> gf
bn AND by -> ca
NOT hr -> hs
NOT bs -> bt
lf RSHIFT 3 -> lh
au AND av -> ax
1 AND gd -> ge
jr OR js -> jt
fw AND fy -> fz
NOT iz -> ja
c LSHIFT 1 -> t
dy RSHIFT 5 -> eb
bp OR bq -> br
NOT h -> i
1 AND ds -> dt
ab AND ad -> ae
ap LSHIFT 1 -> bj
br AND bt -> bu
NOT ca -> cb
NOT el -> em
s LSHIFT 15 -> w
gk OR gq -> gr
ff AND fh -> fi
kf LSHIFT 15 -> kj
fp AND fv -> fx
lh OR li -> lj
bn RSHIFT 3 -> bp
jp OR ka -> kb
lw OR lv -> lx
iy AND ja -> jb
dy OR ej -> ek
1 AND bh -> bi
NOT kt -> ku
ao OR an -> ap
ia AND ig -> ii
NOT ey -> ez
bn RSHIFT 1 -> cg
fk OR fj -> fl
ce OR cd -> cf
eu AND fa -> fc
kg OR kf -> kh
jr AND js -> ju
iu RSHIFT 3 -> iw
df AND dg -> di
dl AND dn -> do
la LSHIFT 15 -> le
fo RSHIFT 1 -> gh
NOT gw -> gx
NOT gb -> gc
ir LSHIFT 1 -> jl
x AND ai -> ak
he RSHIFT 5 -> hh
1 AND lu -> lv
NOT ft -> fu
gh OR gi -> gj
lf RSHIFT 5 -> li
x RSHIFT 3 -> z
b RSHIFT 3 -> e
he RSHIFT 2 -> hf
NOT fx -> fy
jt AND jv -> jw
hx OR hy -> hz
jp AND ka -> kc
fb AND fd -> fe
hz OR ik -> il
ci RSHIFT 1 -> db
fo AND fz -> gb
fq AND fr -> ft
gj RSHIFT 2 -> gk
cg OR ch -> ci
cd LSHIFT 15 -> ch
jm LSHIFT 1 -> kg
ih AND ij -> ik
fo RSHIFT 3 -> fq
fo RSHIFT 5 -> fr
1 AND fi -> fj
1 AND kz -> la
iu AND jf -> jh
cq AND cs -> ct
dv LSHIFT 1 -> ep
hf OR hl -> hm
km AND kn -> kp
de AND dk -> dm
dd RSHIFT 5 -> dg
NOT lo -> lp
NOT ju -> jv
NOT fg -> fh
cm AND co -> cp
ea AND eb -> ed
dd RSHIFT 3 -> df
gr AND gt -> gu
ep OR eo -> eq
cj AND cp -> cr
lf OR lq -> lr
gg LSHIFT 1 -> ha
et RSHIFT 2 -> eu
NOT jh -> ji
ek AND em -> en
jk LSHIFT 15 -> jo
ia OR ig -> ih
gv AND gx -> gy
et AND fe -> fg
lh AND li -> lk
1 AND io -> ip
kb AND kd -> ke
kk RSHIFT 5 -> kn
id AND if -> ig
NOT ls -> lt
dw OR dx -> dy
dd AND do -> dq
lf AND lq -> ls
NOT kc -> kd
dy AND ej -> el
1 AND ke -> kf
et OR fe -> ff
hz RSHIFT 5 -> ic
dd OR do -> dp
cj OR cp -> cq
NOT dq -> dr
kk RSHIFT 1 -> ld
jg AND ji -> jj
he OR hp -> hq
hi AND hk -> hl
dp AND dr -> ds
dz AND ef -> eh
hz RSHIFT 3 -> ib
db OR dc -> dd
hw LSHIFT 1 -> iq
he AND hp -> hr
NOT cr -> cs
lg AND lm -> lo
hv OR hu -> hw
il AND in -> io
NOT eh -> ei
gz LSHIFT 15 -> hd
gk AND gq -> gs
1 AND en -> eo
NOT kp -> kq
et RSHIFT 5 -> ew
lj AND ll -> lm
he RSHIFT 3 -> hg
et RSHIFT 3 -> ev
as AND bd -> bf
cu AND cw -> cx
jx AND jz -> ka
b OR n -> o
be AND bg -> bh
1 AND ht -> hu
1 AND gy -> gz
NOT hn -> ho
ck OR cl -> cm
ec AND ee -> ef
lv LSHIFT 15 -> lz
ks AND ku -> kv
NOT ie -> if
hf AND hl -> hn
1 AND r -> s
ib AND ic -> ie
hq AND hs -> ht
y AND ae -> ag
NOT ed -> ee
bi LSHIFT 15 -> bm
dy RSHIFT 2 -> dz
ci RSHIFT 2 -> cj
NOT bf -> bg
NOT im -> in
ev OR ew -> ex
ib OR ic -> id
bn RSHIFT 2 -> bo
dd RSHIFT 2 -> de
bl OR bm -> bn
as RSHIFT 1 -> bl
ea OR eb -> ec
ln AND lp -> lq
kk RSHIFT 3 -> km
is OR it -> iu
iu RSHIFT 2 -> iv
as OR bd -> be
ip LSHIFT 15 -> it
iw OR ix -> iy
kk RSHIFT 2 -> kl
NOT bb -> bc
ci RSHIFT 5 -> cl
ly OR lz -> ma
z AND aa -> ac
iu RSHIFT 1 -> jn
cy LSHIFT 15 -> dc
cf LSHIFT 1 -> cz
as RSHIFT 3 -> au
cz OR cy -> da
kw AND ky -> kz
lx -> a
iw AND ix -> iz
lr AND lt -> lu
jp RSHIFT 5 -> js
aw AND ay -> az
jc AND je -> jf
lb OR la -> lc
NOT cn -> co
kh LSHIFT 1 -> lb
1 AND jj -> jk
y OR ae -> af
ck AND cl -> cn
kk OR kv -> kw
NOT cv -> cw
kl AND kr -> kt
iu OR jf -> jg
at AND az -> bb
jp RSHIFT 2 -> jq
iv AND jb -> jd
jn OR jo -> jp
x OR ai -> aj
ba AND bc -> bd
jl OR jk -> jm
b RSHIFT 1 -> v
o AND q -> r
NOT p -> q
k AND m -> n
as RSHIFT 2 -> at";
    }
}
