using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Uebung_5_6_Incrementer_Decrementer
{
    /// <summary>
    /// Siehe ganz unten ein möglicher Output mit Fehler
    /// </summary>
    public class ThreadTester
    {
        private readonly string filename = "ThreadOutput.txt";
        private readonly object lockObject = new object();
        private StreamWriter filestream;

        public void DoTest()
        {
            LöscheDateiFallsSieSchonExistiert();
            filestream = new StreamWriter(filename);


            var incremeterThreadStart = new ParameterizedThreadStart(Incrementer);
            var incrementer = new Thread(incremeterThreadStart);
            incrementer.Name = "Incr.";

            var decrementerThreadStart = new ParameterizedThreadStart(Decrementer);
            var decrementer = new Thread(decrementerThreadStart);
            decrementer.Name = "Decr.";

            incrementer.Start(new MinMaxThreadreferenceTuple(1, 500, decrementer));
            decrementer.Start(new MinMaxThreadreferenceTuple(700, 1000, null));

            incrementer.Join(); // Ohne diese Zeile kommt ein "Cannot write to a closed TextWriter.", weil der Stream geschlossen wird bevor die Threads fertig sind
            decrementer.Join(); // Ohne diese Zeile kommt ein "Cannot write to a closed TextWriter.", weil der Stream geschlossen wird bevor die Threads fertig sind
            filestream.Flush();
            filestream.Close();
            //OrdnerÖffnenWoDieTextdateiLiegt();
            DateiÖffnen();
        }

        private void LöscheDateiFallsSieSchonExistiert()
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        private void DateiÖffnen()
        {
            string dateipfad = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), filename);
            Process.Start(dateipfad);
        }

        private static void OrdnerÖffnenWoDieTextdateiLiegt()
        {
            string ordnerpfad = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Process.Start(ordnerpfad);
        }

        private void Incrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple)parameter;

            for (int i = minMaxTuple.Min; i <= minMaxTuple.Max; i++)
            {
                //lock (lockObject) // Diese Lock stellt sicher, dass beim Schreiben die Zeile zusammenbleibt und nicht unterbrochen wird
                //{
                    string output = string.Format($"Incrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                    foreach (char c in output)
                    {
                        lock (lockObject) // Damit nicht beide Threads exakt gleichzeitig ein Write ausführen, was zu einer Exception führen würde:
                                          // Probable I/O race condition detected while copying memory. The I/O package is not thread safe by default. In multithreaded applications, a stream must be accessed in a thread-safe way, such as a thread-safe wrapper returned by TextReader's or TextWriter's Synchronized methods. This also applies to classes like StreamWriter and StreamReader.
                        {
                            filestream.Write(c);
                        }
                    }
                    filestream.Write(Environment.NewLine);
                //}
            }
        }

        private void Decrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple)parameter;

            for (int i = minMaxTuple.Max; i >= minMaxTuple.Min; i--)
            {
                //lock (lockObject) // Diese Lock stellt sicher, dass beim Schreiben die Zeile zusammenbleibt und nicht unterbrochen wird
                //{
                    string output = string.Format($"Decrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                    foreach (char c in output)
                    {
                        lock (lockObject) // Damit nicht beide Threads exakt gleichzeitig ein Write ausführen, was zu einer Exception führen würde:
                                          // Probable I/O race condition detected while copying memory. The I/O package is not thread safe by default. In multithreaded applications, a stream must be accessed in a thread-safe way, such as a thread-safe wrapper returned by TextReader's or TextWriter's Synchronized methods. This also applies to classes like StreamWriter and StreamReader.
                        {
                            filestream.Write(c);
                        }
                    }
                    filestream.Write(Environment.NewLine);
                //}
            }
        }
    }
}

/*

----------------------------------------------------------------------
--- Fehlerhafte Ausgabe, wenn man ohne Locks in die Datei schreibt ---
----------------------------------------------------------------------

Decrementer Id=4 Name=Decr.: 1000Increm
  ter Id=3 Name=Incr.:    1
Decrementer Id=4 Name=Decr.:  999
Decrementer Id=4 Name=Decr.:  998
Incrementer Id=3 Name=Incr.:    2
Decrementer Id=4 Name=Decr.:  997
Decrementer Id=4 Name=Decr.:  996
Decrementer Id=4 Name=Decr.:  995
Incrementer Id=3 NDecrementer Id=4 Name=Decr.:  994
ame=IncrDecrementer Id=4 Name=Decr.:  993
.:  Decrementer Id=4 Name=Decr.:  992
  3
Decrementer Id=4 Name=Decr.:  991
Decrementer Id=4 Name=Decr.:  990
Incrementer Id=3 Name=Incr.:    4
Decrementer Id=4 Name=Decr.:  989
Incrementer Id=3 Name=Incr.:    5
Decrementer Id=4 Name=Decr.:  988
Decrementer Id=4 Name=Decr.:  987
Decrementer Id=4 Name=Decr.:  986
Incrementer Id=3 Name=Incr.:    6
Decrementer Id=4 Name=Decr.:  985
IncreDecrementer Id=4 Name=Decr.:  984
menter Id=3 Name=Incr.:    7
Decrementer Id=4 Name=Decr.:  983
Incrementer Id=3 Name=Incr.:    8
Incrementer Id=3 NamDecrementer Id=4 Name=Decr.:  982
e=Incr.:    9
Decrementer Id=4 Name=Decr.:  981
Decrementer Id=4 Name=Decr.:  980
Decrementer Id=4 Name=Decr.:  979
Decrementer Id=4 Name=Decr.:  978
Decrementer Id=4 Name=Decr.:  977
Decrementer Id=4 Name=Decr.:  976
Decrementer Id=4 Name=Decr.:  975
Decrementer Id=4 Name=Decr.:  974
Decrementer Id=4 Name=Decr.:  973
Decrementer Id=4 Name=Decr.:  972
Decrementer Id=4 Name=Decr.:  971
Incrementer Id=3Decrementer Id=4 Name=Decr.:  970
 Name=Incr.:   10
ecrementer Id=4 Name=Decr.:  969
Decrementer Id=4 Name=Decr.:  968
Incrementer Id=3 Name=Incr.:   11
Decrementer Id=4 Name=Decr.:  967
Decrementer Id=4 Name=Decr.:  966
Decrementer Id=4 Name=Decr.:  965
Incrementer Id=3 Name=Incr.:   12
Decrementer Id=4 Name=Decr.:  964
Incrementer Id=3 Name=Incr.:   13
Decrementer Id=4 Name=Decr.:  963
Incrementer Id=3 Name=Incr.:   14
Decrementer Id=4 Name=Decr.:  962
Incrementer Id=3 Name=Incr.:   15
Decrementer Id=4Incrementer Id=3 Name=Incr.:   16
 Name=Decr.:  961
Incrementer Id=3 Name=Incr.:   17
Incrementer Id=3 Name=Incr.:   18
Decrementer Id=4 Name=Decr.:  960
Decrementer Id=4 Name=Decr.:  959
Decrementer Id=4 Name=Decr.:  958
Decrementer Id=4 Name=Decr.:  957
Decrementer Id=4 Name=Decr.:  956
Incrementer Id=3 Name=Incr.:   19
Decrementer Id=4 Name=Decr.:  955
Decrementer Id=4 Name=Decr.:  954
Decrementer Id=4 Name=Decr.:  953
Incrementer Id=3 Name=Incr.:   20
Decrementer Id=4 Name=Decr.:  952
Incrementer Id=3 Name=Incr.:   21
Decrementer Id=4 Name=Decr.:  951
Incrementer Id=3 Name=Incr.:   22
Decrementer Id=4 Name=Decr.:  950
Incrementer Id=3 Name=Incr.:   23
Decrementer Id=4 Name=Decr.:  949
Incrementer Id=3 Name=Incr.:   24
Incrementer Id=3 Name=Incr.:   25
Incrementer Id=3 Name=Incr.:   26
Decrementer Id=4 Name=DecIncrementer Id=3 Name=Incr.:   27
r.:  948
Incrementer Id=3 Name=Incr.:   28
Incrementer Id=3 Name=Incr.:   29
Incrementer Id=3 Name=Incr.:   30
Decrementer Id=4 Name=Decr.:  947
Incrementer Id=3 Name=Incr.:   31
Decrementer Id=4 Name=Decr.:  946
Incrementer Id=3 Name=Incr.:   32
Decrementer Id=4 Name=Decr.:  945
Decrementer Id=4 Name=Decr.:  944
Decrementer Id=4 Name=Decr.:  943
Decrementer Id=4 Name=Decr.:  942
Decrementer Id=4 Name=Decr.:  941
Decrementer Id=4 Name=Decr.:  940
Decrementer Id=4 Name=Decr.:  939
Decrementer Id=4 Name=Decr.:  938
Decrementer Id=4 Name=Decr.:  937
Decrementer Id=4 Name=Decr.:  936
Decrementer Id=4 Name=Decr.:  935
Decrementer Id=4 Name=Decr.:  934
Decrementer Id=4 Name=Decr.:  933
Decrementer Id=4 Name=Decr.:  932
Decrementer Id=4 Name=Decr.:  931
Decrementer Id=4 Name=Decr.:  930
Decrementer Id=4 Name=Decr.:  929
Decrementer Id=4 Name=Decr.:  928
Decrementer Id=4 Name=Decr.:  927
Decrementer Id=4 Name=Decr.:  926
Decrementer Id=4 Name=Decr.:  925
Incrementer Id=3 Name=Incr.:   33
Decrementer Id=4 Name=Decr.:  924
Incrementer Id=3 Name=Incr.:   34
Decrementer Id=4 Name=Decr.:  923
Incrementer Id=3 Name=Incr.:   35
Decrementer Id=4 NIncrementer Id=3 Name=Incr.:   36
ame=Decr.:  922
Incrementer Id=3 Name=Incr.:   37
Decrementer Id=4 Name=Decr.:  921
Incrementer Id=3 Name=Incr.:   38
Incrementer Id=3 Name=Incr.:   39
Decrementer Id=4 Name=Decr.:  920
Incrementer Id=3 Name=Incr.:   40
Decrementer Id=4 Name=Decr.:  919
Incrementer Id=3 Name=Incr.:   41
Decrementer Id=4 Name=Decr.:  918
Incrementer Id=3 Name=Incr.:   42
Decrementer Id=4 Name=Decr.:  917
Decrementer Id=4 Name=Decr.:  916
Decrementer Id=4 Name=Decr.:  915
Decrementer Id=4 Name=Decr.:  914
Decrementer Id=4 Name=Decr.:  913
Decrementer Id=4 Name=Decr.:  912
Decrementer Id=4 Name=Decr.:  911
Decrementer Id=4 Name=Decr.:  910
Decrementer Id=4 Name=Decr.:  909
Decrementer Id=4 Name=Decr.:  908
Decrementer Id=4 Name=Decr.:  907
Decrementer Id=4 Name=Decr.:  906
Decrementer Id=4 Name=Decr.:  905
Incrementer Id=3 Name=Incr.:   43
Decrementer Id=4 Name=Decr.:  904
Incrementer Id=3 Name=Incr.:   44
Decrementer Id=4 Name=Decr.:  903
Incrementer Id=3 Name=Incr.:   45
Decrementer Id=4 Name=Decr.:  902
Incrementer Id=3 Name=Incr.:   46
Decrementer Id=4 Name=Decr.:  901
Incrementer Id=3 Name=Incr.:   47
Incrementer Id=3 Name=Incr.:   48
Incrementer Id=3 Name=Incr.:   49
Incrementer Id=3 Name=Incr.:   50
Incrementer Id=3 Name=Incr.:   51
Incrementer Id=3 Name=Incr.:   52
Decrementer Id=4 Name=Decr.:  900
Incrementer Id=3 Name=Incr.:   53
Decrementer Id=4 Name=Decr.:  899
Incrementer Id=3 Name=Incr.:   54
Decrementer Id=4 Name=Decr.:  898
Incrementer Id=3 NameDecrementer Id=4 Name=Decr.:  897
=Incr.:   55
Decrementer Id=4 Name=Decr.:  896
Incrementer Id=3 Name=Incr.:   56
Decrementer Id=4 Name=Decr.:  895
Incrementer Id=3 Name=Incr.:   57
Decrementer Id=4 Name=Decr.:  894
Incrementer Id=3 Name=Incr.:   58
Decrementer Id=4 Name=Decr.:  893
Decrementer Id=4 Name=Decr.:  892
Decrementer Id=4 Name=Decr.:  891
Incrementer Id=3 Name=Incr.:   59
Decrementer Id=4 Name=Decr.:  890
Incrementer Id=3 Name=Incr.:   60
Decrementer Id=4 Name=Decr.:  889
Incrementer Id=3 Name=Incr.:   61
Decrementer Id=4 Name=Decr.:  888
Incrementer Id=3 Name=Incr.:   62
Decrementer Id=4 Name=Decr.:  887
Decrementer Id=4 Name=Decr.:  886
Incrementer Id=3 Name=Incr.:   63
Decrementer Id=4 Name=Decr.:  885
Decrementer Id=4 Name=Decr.:  884
Decrementer Id=4 Name=Decr.:  883
Incrementer Id=3 Name=Incr.:   64
Incrementer Id=3 Name=Incr.:   65
Incrementer Id=3 Name=Incr.:   66
Decrementer Id=4 Name=Decr.:  882
Decrementer Id=4 Name=Decr.:  881
Incrementer Id=3 Name=Incr.:   67
Incrementer Id=3 Name=Incr.:   68
Decrementer Id=4 Name=Decr.:  880
Incrementer Id=3 Name=Incr.:   69
Decrementer Id=4 Name=Decr.Incrementer Id=3 Name=Incr.:   70
:  879
Incrementer Id=3 Name=Incr.:   71
Incrementer Id=3 Name=Incr.:   72
Incrementer Id=3 Name=Incr.:   73
Incrementer Id=3 Name=Incr.:   74
Decrementer Id=4 Name=Decr.:  878
Incrementer Id=3 Name=Incr.:   75
Incrementer Id=3 Name=Incr.:   76
Incrementer Id=3 Name=Incr.:   77
Incrementer Id=3 Name=Incr.:   78
Decrementer Id=4 Name=Decr.:  877
Incrementer Id=3 Name=Incr.:   79
Decrementer Id=4 Name=Decr.:  876
Incrementer Id=3 Name=Incr.:   80
Incrementer Id=3 Name=Incr.:   81
Incrementer Id=3 Name=Incr.:   82
Incrementer Id=3 Name=Incr.:   83
Incrementer Id=3 Name=Incr.:   84
Incrementer Id=3 Name=Incr.:   85
Incrementer Id=3 Name=Incr.:   86
Incrementer Id=3 Name=Incr.:   87
Incrementer Id=3 Name=Incr.:   88
Incrementer Id=3 Name=Incr.:   89
Incrementer Id=3 Name=Incr.:   90
Incrementer Id=3 Name=Incr.:   91
Incrementer Id=3 Name=Incr.:   92
Incrementer Id=3 Name=Incr.:   93
Incrementer Id=3 Name=Incr.:   94
Incrementer Id=3 Name=Incr.:   95
Incrementer Id=3 Name=Incr.:   96
Incrementer Id=3 Name=Incr.:   97
Incrementer Id=3 Name=Incr.:   98
Incrementer Id=3 Name=Incr.:   99
Incrementer Id=3 Name=Incr.:  100
Decrementer Id=4 Name=Decr.:  875
Incrementer Id=3 Name=Incr.:  101
Incrementer Id=3 Name=Incr.:  102
Incrementer Id=3 Name=Incr.:  103
DecrementeIncrementer Id=3 Name=Incr.:  104
r Id=4 Name=Decr.:  874
Decrementer Id=4 Name=Decr.:  873
Decrementer Id=4 Name=Decr.:  872
Incrementer Id=3 Name=Incr.:  105
Decrementer Id=4 Name=Decr.:  871
Decrementer Id=4 Name=Decr.:  870
Decrementer Id=4 Name=Decr.:  869
Decrementer Id=4 Name=Decr.:  868
Decrementer Id=4 Name=Decr.:  867
Decrementer Id=4 Name=Decr.:  866
Decrementer Id=4 Name=Decr.:  865
Decrementer Id=4 Name=Decr.:  864
Decrementer Id=4 Name=Decr.:  863
Decrementer Id=4 Name=Decr.:  862
Decrementer Id=4 Name=Decr.:  861
Decrementer Id=4 Name=Decr.:  860
Decrementer Id=4 Name=Decr.:  859
Decrementer Id=4 Name=Decr.:  858
Decrementer Id=4 Name=Decr.:  857
Decrementer Id=4 Name=Decr.:  856
Decrementer Id=4 Name=Decr.:  855
Decrementer Id=4 Name=Decr.:  854
Decrementer Id=4 Name=Decr.:  853
Incrementer Id=3 Name=Incr.:  106
Decrementer Id=4 Name=Decr.:  852
Incrementer Id=3 Name=Incr.:  107
Decrementer Id=4 Name=Decr.:  851
Incrementer Id=3 Name=Incr.:  108
Decrementer Id=4 Name=Decr.:  850
Incrementer Id=3 Name=Incr.:  109
Decrementer Id=4 Name=Decr.:  849
Incrementer Id=3 Name=Incr.:  110
Decrementer Id=4 Name=Decr.:  848
Incrementer Id=3 Name=Incr.:  111
Incrementer Id=3 Name=Incr.:  112
Incrementer Id=3 Name=Incr.:  113
Incrementer Id=3 Name=Incr.:  114
Incrementer Id=3 Name=Incr.:  115
Incrementer Id=3 Name=Incr.:  116
Incrementer Id=3 Name=Incr.:  117
Incrementer Id=3 Name=Incr.:  118
Incrementer Id=3 Name=Incr.:  119
Incrementer Id=3 Name=Incr.:  120
Incrementer Id=3 Name=Incr.:  121
Incrementer Id=3 Name=Incr.:  122
Incrementer Id=3 Name=Incr.:  123
Incrementer Id=3 Name=Incr.:  124
Incrementer Id=3 Name=Incr.:  125
Incrementer Id=3 Name=Incr.:  126
Incrementer Id=3 Name=Incr.:  127
Incrementer Id=3 Name=Incr.:  128
Incrementer Id=3 Name=Incr.:  129
Incrementer Id=3 Name=Incr.:  130
Incrementer Id=3 Name=Incr.:  131
Incrementer Id=3 Name=Incr.:  132
Incrementer Id=3 Name=Incr.:  133
Incrementer Id=3 Name=Incr.:  134
Incrementer Id=3 Name=Incr.:  135
Incrementer Id=3 Name=Incr.:  136
Incrementer Id=3 Name=Incr.:  137
Incrementer Id=3 Name=Incr.:  138
Incrementer Id=3 Name=Incr.:  139
Incrementer Id=3 Name=Incr.:  140
Incrementer Id=3 Name=Incr.:  141
Incrementer Id=3 Name=Incr.:  142
Incrementer Id=3 Name=Incr.:  143
Incrementer Id=3 Name=Incr.:  144
Incrementer Id=3 Name=Incr.:  145
Incrementer Id=3 Name=Incr.:  146
Incrementer Id=3 Name=Incr.:  147
Incrementer Id=3 Name=Incr.:  148
Incrementer Id=3 Name=Incr.:  149
Incrementer Id=3 Name=Incr.:  150
Incrementer Id=3 Name=Incr.:  151
Incrementer Id=3 Name=Incr.:  152
Incrementer Id=3 Name=Incr.:  153
Incrementer Id=3 Name=Incr.:  154
Decrementer Id=4 Name=Decr.:  847
Incrementer Id=3 Name=Incr.:  155
Decrementer Id=4 Name=Decr.:  846
Incrementer Id=3 Name=Incr.:  156
Incrementer Id=3 Name=Incr.:  157
Incrementer Id=3 Name=Incr.:  158
Decrementer Id=4 Name=Decr.:  845
Incrementer Id=3 Name=Incr.:  159
Decrementer Id=4 Name=Decr.:  844
Incrementer Id=3 Name=Incr.:  160
Decrementer Id=4 Name=Decr.:  843
Decrementer Id=4 Name=Decr.:  842
Decrementer Id=4 Name=Decr.:  841
Incrementer Id=3 Name=Incr.:  161
Incrementer Id=3 Name=Incr.:  162
Incrementer Id=3 Name=Incr.:  163
Incrementer Id=3 Name=Incr.:  164
Incrementer Id=3 Name=Incr.:  165
Incrementer Id=3 Name=Incr.:  166
Incrementer Id=3 Name=Incr.:  167
Incrementer Id=3 Name=Incr.:  168
Decrementer Id=Incrementer Id=3 Name=Incr.:  169
4 Name=Decr.:  840
Incrementer Id=3 Name=Incr.:  170
Incrementer Id=3 Name=Incr.:  171
Incrementer Id=3 Name=Incr.:  172
Decrementer Id=4 Name=Decr.:  839
Incrementer Id=3 Name=Incr.:  173
Decrementer Id=4 Name=Decr.:  838
Incrementer Id=3 Name=Incr.:  174
Decrementer Id=4 Name=Decr.:  837
Incrementer Id=3 Name=Incr.:  175
Decrementer Id=4 Name=Decr.:  836
Incrementer Id=3 Name=Incr.:  176
Decrementer Id=4 Name=Decr.:  835
Incrementer Id=3 Name=Incr.:  177
Decrementer Id=4 Name=Decr.:  834
Incrementer Id=3 Name=Incr.:  178
Decrementer Id=4 Name=Decr.:  833
Decrementer Id=4 Name=Decr.:  832
Decrementer Id=4 Name=Decr.:  831
Incrementer Id=3 Name=Incr.:  179
Decrementer Id=4 Name=Decr.:  830
Incrementer Id=3 Name=Incr.:  180
Incrementer Id=3 Name=Incr.:  181
Decrementer Id=4 Name=Decr.:  829
Incrementer Id=3 Name=Incr.:  182
Decrementer Id=4 Name=Decr.:  828
Incrementer Id=3 Name=Incr.:  183
Decrementer Id=4 Name=Decr.:  827
Incrementer Id=3 Name=Incr.:  184
Decrementer Id=4 Name=Decr.:  826
Decrementer Id=4 Name=Decr.:  825
Decrementer Id=4 Name=Decr.:  824
Incrementer Id=3 Name=Incr.:  185
Decrementer Id=4 Name=Decr.:  823
Decrementer Id=4 Name=Decr.:  822
Decrementer Id=4 Name=Decr.:  821
Incrementer Id=3 Name=Incr.:  186
Decrementer IIncrementer Id=3 Name=Incr.:  187
d=4 Name=Decr.:  820
Incrementer Id=3 Name=Incr.:  188
Incrementer Id=3 Name=Incr.:  189
Incrementer Id=3 Name=Incr.:  190
Decrementer Id=4 Name=Decr.:  819
Incrementer Id=3 Name=Incr.:  191
Decrementer Id=4 Name=Decr.:  818
Incrementer Id=3 Name=Incr.:  192
Decrementer Id=4 Name=Decr.:  817
Incrementer Id=3 Name=Incr.:  193
Decrementer Id=4 Name=Decr.:  816
Incrementer Id=3 Name=Incr.:  194
Decrementer Id=4 Name=Decr.:  815
Incrementer Id=3 Name=Incr.:  195
Decrementer Id=4 Name=Decr.:  814
Incrementer Id=3 Name=Incr.:  196
Decrementer Id=4 Name=Decr.:  813
Incrementer Id=3 Name=Incr.:  197
DecremeIncrementer Id=3 Name=Incr.:  198
nter Id=4 Name=Decr.:  812
Decrementer Id=4 Name=Decr.:  811
Decrementer Id=4 Name=Decr.:  810
Incrementer Id=3 Name=Incr.:  199
Decrementer Id=4 Name=Decr.:  809
Incrementer Id=3 Name=Incr.:  200
Decrementer Id=4 Name=Decr.:  808
Incrementer Id=3 Name=Incr.:  201
Decrementer Id=4 Name=Decr.:  807
Incrementer Id=3 Name=Incr.:  202
Incrementer Id=3 Name=Incr.:  203
Incrementer Id=3 Name=Incr.:  204
Decrementer Id=4 Name=Decr.:  806
Incrementer Id=3 Name=Incr.:  205
Decrementer Id=4 Name=Decr.:  805
Incrementer Id=3 Name=Incr.:  206
Decrementer Id=4 Name=Decr.:  804
Decrementer Id=4 Name=Decr.:  803
Decrementer Id=4 Name=Decr.:  802
Incrementer Id=3 Name=Incr.:  207
Decrementer Id=4 Name=Decr.:  801
Incrementer Id=3 Name=Incr.:  208
Decrementer Id=4 Name=Decr.:  800
Decrementer Id=4 Name=Decr.:  799
Incrementer Id=3 Name=Incr.:  209
Decrementer Id=4 Name=Decr.:  798
Incrementer Id=3 Name=Incr.:  210
Decrementer Id=4 Name=Decr.:  797
Incrementer Id=3 Name=Incr.:  211
Decrementer Id=4 NaIncrementer Id=3 Name=Incr.:  212
me=Decr.:  796
Incrementer Id=3 Name=Incr.:  213
Decrementer Id=4 Name=Decr.:  795
Incrementer Id=3 Name=Incr.:  214
Incrementer Id=3 Name=Incr.:  215
Incrementer Id=3 Name=Incr.:  216
Decrementer Id=4 Name=Decr.:  794
Incrementer Id=3 Name=Incr.:  217
Decrementer Id=4 Name=Decr.:  793
Incrementer Id=3 Name=Incr.:  218
Decrementer Id=4 Name=Decr.:  792
Incrementer Id=3 Name=Incr.:  219
DecrementeIncrementer Id=3 Name=Incr.:  220
r Id=4 Name=Decr.:  791
Decrementer Id=4 Name=Decr.:  790
Decrementer Id=4 Name=Decr.:  789
Incrementer Id=3 Name=Incr.:  221
Decrementer Id=4 Name=Decr.:  788
Incrementer Id=3 Name=Incr.:  222
Decrementer Id=4 Name=Decr.:  787
Incrementer Id=3 Name=Incr.:  223
Decrementer Id=4 Name=Decr.:  786
Incrementer Id=3 Name=Incr.:  224
Incrementer Id=3 Name=Incr.:  225
Incrementer Id=3 Name=Incr.:  226
Incrementer Id=3 Name=Incr.:  227
Incrementer Id=3 Name=Incr.:  228
Incrementer Id=3 Name=Incr.:  229
Incrementer Id=3 Name=Incr.:  230
Incrementer Id=3 Name=Incr.:  231
Incrementer Id=3 Name=Incr.:  232
Incrementer Id=3 Name=Incr.:  233
Incrementer Id=3 Name=Incr.:  234
Incrementer Id=3 Name=Incr.:  235
Incrementer Id=3 Name=Incr.:  236
Incrementer Id=3 Name=Incr.:  237
Incrementer Id=3 Name=Incr.:  238
Incrementer Id=3 Name=Incr.:  239
Incrementer Id=3 Name=Incr.:  240
Decrementer Id=4 Name=Decr.:  785
Incrementer Id=3 Name=Incr.:  241
Decrementer Id=4 Name=Decr.:  784
Incrementer Id=3 Name=Incr.:  242
Decrementer Id=4 Incrementer Id=3 Name=Incr.:  243
Name=Decr.:  783
Incrementer Id=3 Name=Incr.:  244
Incrementer Id=3 Name=Incr.:  245
Incrementer Id=3 Name=Incr.:  246
Decrementer Id=4 Name=Decr.:  782
Incrementer Id=3 Name=Incr.:  247
Decrementer Id=4 Name=Decr.:  781
Incrementer Id=3 Name=Incr.:  248
Decrementer Id=4 Name=Decr.:  780
Decrementer Id=4 Name=Decr.:  779
Decrementer Id=4 Name=Decr.:  778
Decrementer Id=4 Name=Decr.:  777
Decrementer Id=4 Name=Decr.:  776
Decrementer Id=4 Name=Decr.:  775
Decrementer Id=4 Name=Decr.:  774
Decrementer Id=4 Name=Decr.:  773
Decrementer Id=4 Name=Decr.:  772
Decrementer Id=4 Name=Decr.:  771
Decrementer Id=4 Name=Decr.:  770
Decrementer Id=4 Name=Decr.:  769
Decrementer Id=4 Name=Decr.:  768
Decrementer Id=4 Name=Decr.:  767
Decrementer Id=4 Name=Decr.:  766
Decrementer Id=4 Name=Decr.:  765
Decrementer Id=4 Name=Decr.:  764
Decrementer Id=4 Name=Decr.:  763
Decrementer Id=4 Name=Decr.:  762
Decrementer Id=4 Name=Decr.:  761
Decrementer Id=4 Name=Decr.:  760
Decrementer Id=4 Name=Decr.:  759
Incrementer Id=3 Name=Incr.:  249
Decrementer Id=4 Name=Decr.:  758
Decrementer Id=4 Name=Decr.:  757
Decrementer Id=4 Name=Decr.:  756
Incrementer Id=3 Name=Incr.:  250
Decrementer Id=4 Name=Decr.:  755
Incrementer Id=3 Name=Incr.:  251
Decrementer Id=4 Name=Decr.:  754
Decrementer Id=4 Name=Decr.:  753
Decrementer Id=4 Name=Decr.:  752
Decrementer Id=4 Name=Decr.:  751
Decrementer Id=4 Name=Decr.:  750
Decrementer Id=4 Name=Decr.:  749
Decrementer Id=4 Name=Decr.:  748
Decrementer Id=4 Name=Decr.:  747
Decrementer Id=4 Name=Decr.:  746
Decrementer Id=4 Name=Decr.:  745
Decrementer Id=4 Name=Decr.:  744
Decrementer Id=4 Name=Decr.:  743
Decrementer Id=4 Name=Decr.:  742
Decrementer Id=4 Name=Decr.:  741
Decrementer Id=4 Name=Decr.:  740
Decrementer Id=4 Name=Decr.:  739
Decrementer Id=4 Name=Decr.:  738
Decrementer Id=4 Name=Decr.:  737
Decrementer Id=4 Name=Decr.:  736
Decrementer Id=4 Name=Decr.:  735
Decrementer Id=4 Name=Decr.:  734
Decrementer Id=4 Name=Decr.:  733
Decrementer Id=4 Name=Decr.:  732
Decrementer Id=4 Name=Decr.:  731
Decrementer Id=4 Name=Decr.:  730
Decrementer Id=4 Name=Decr.:  729
Decrementer Id=4 Name=Decr.:  728
Decrementer Id=4 Name=Decr.:  727
Decrementer Id=4 Name=Decr.:  726
Decrementer Id=4 Name=Decr.:  725
Decrementer Id=4 Name=Decr.:  724
Decrementer Id=4 Name=Decr.:  723
Decrementer Id=4 Name=Decr.:  722
Decrementer Id=4 Name=Decr.:  721
Decrementer Id=4 Name=Decr.:  720
Decrementer Id=4 Name=Decr.:  719
Decrementer Id=4 Name=Decr.:  718
Decrementer Id=4 Name=Decr.:  717
Decrementer Id=4 Name=Decr.:  716
Decrementer Id=4 Name=Decr.:  715
Decrementer Id=4 Name=Decr.:  714
Decrementer Id=4 Name=Decr.:  713
Decrementer Id=4 Name=Decr.:  712
Decrementer Id=4 Name=Decr.:  711
Decrementer Id=4 Name=Decr.:  710
Decrementer Id=4 Name=Decr.:  709
Decrementer Id=4 Name=Decr.:  708
Decrementer Id=4 Name=Decr.:  707
Decrementer Id=4 Name=Decr.:  706
Decrementer Id=4 Name=Decr.:  705
Decrementer Id=4 Name=Decr.:  704
Decrementer Id=4 Name=Decr.:  703
Decrementer Id=4 Name=Decr.:  702
Decrementer Id=4 Name=Decr.:  701
Decrementer Id=4 Name=Decr.:  700
Incrementer Id=3 Name=Incr.:  252
Incrementer Id=3 Name=Incr.:  253
Incrementer Id=3 Name=Incr.:  254
Incrementer Id=3 Name=Incr.:  255
Incrementer Id=3 Name=Incr.:  256
Incrementer Id=3 Name=Incr.:  257
Incrementer Id=3 Name=Incr.:  258
Incrementer Id=3 Name=Incr.:  259
Incrementer Id=3 Name=Incr.:  260
Incrementer Id=3 Name=Incr.:  261
Incrementer Id=3 Name=Incr.:  262
Incrementer Id=3 Name=Incr.:  263
Incrementer Id=3 Name=Incr.:  264
Incrementer Id=3 Name=Incr.:  265
Incrementer Id=3 Name=Incr.:  266
Incrementer Id=3 Name=Incr.:  267
Incrementer Id=3 Name=Incr.:  268
Incrementer Id=3 Name=Incr.:  269
Incrementer Id=3 Name=Incr.:  270
Incrementer Id=3 Name=Incr.:  271
Incrementer Id=3 Name=Incr.:  272
Incrementer Id=3 Name=Incr.:  273
Incrementer Id=3 Name=Incr.:  274
Incrementer Id=3 Name=Incr.:  275
Incrementer Id=3 Name=Incr.:  276
Incrementer Id=3 Name=Incr.:  277
Incrementer Id=3 Name=Incr.:  278
Incrementer Id=3 Name=Incr.:  279
Incrementer Id=3 Name=Incr.:  280
Incrementer Id=3 Name=Incr.:  281
Incrementer Id=3 Name=Incr.:  282
Incrementer Id=3 Name=Incr.:  283
Incrementer Id=3 Name=Incr.:  284
Incrementer Id=3 Name=Incr.:  285
Incrementer Id=3 Name=Incr.:  286
Incrementer Id=3 Name=Incr.:  287
Incrementer Id=3 Name=Incr.:  288
Incrementer Id=3 Name=Incr.:  289
Incrementer Id=3 Name=Incr.:  290
Incrementer Id=3 Name=Incr.:  291
Incrementer Id=3 Name=Incr.:  292
Incrementer Id=3 Name=Incr.:  293
Incrementer Id=3 Name=Incr.:  294
Incrementer Id=3 Name=Incr.:  295
Incrementer Id=3 Name=Incr.:  296
Incrementer Id=3 Name=Incr.:  297
Incrementer Id=3 Name=Incr.:  298
Incrementer Id=3 Name=Incr.:  299
Incrementer Id=3 Name=Incr.:  300
Incrementer Id=3 Name=Incr.:  301
Incrementer Id=3 Name=Incr.:  302
Incrementer Id=3 Name=Incr.:  303
Incrementer Id=3 Name=Incr.:  304
Incrementer Id=3 Name=Incr.:  305
Incrementer Id=3 Name=Incr.:  306
Incrementer Id=3 Name=Incr.:  307
Incrementer Id=3 Name=Incr.:  308
Incrementer Id=3 Name=Incr.:  309
Incrementer Id=3 Name=Incr.:  310
Incrementer Id=3 Name=Incr.:  311
Incrementer Id=3 Name=Incr.:  312
Incrementer Id=3 Name=Incr.:  313
Incrementer Id=3 Name=Incr.:  314
Incrementer Id=3 Name=Incr.:  315
Incrementer Id=3 Name=Incr.:  316
Incrementer Id=3 Name=Incr.:  317
Incrementer Id=3 Name=Incr.:  318
Incrementer Id=3 Name=Incr.:  319
Incrementer Id=3 Name=Incr.:  320
Incrementer Id=3 Name=Incr.:  321
Incrementer Id=3 Name=Incr.:  322
Incrementer Id=3 Name=Incr.:  323
Incrementer Id=3 Name=Incr.:  324
Incrementer Id=3 Name=Incr.:  325
Incrementer Id=3 Name=Incr.:  326
Incrementer Id=3 Name=Incr.:  327
Incrementer Id=3 Name=Incr.:  328
Incrementer Id=3 Name=Incr.:  329
Incrementer Id=3 Name=Incr.:  330
Incrementer Id=3 Name=Incr.:  331
Incrementer Id=3 Name=Incr.:  332
Incrementer Id=3 Name=Incr.:  333
Incrementer Id=3 Name=Incr.:  334
Incrementer Id=3 Name=Incr.:  335
Incrementer Id=3 Name=Incr.:  336
Incrementer Id=3 Name=Incr.:  337
Incrementer Id=3 Name=Incr.:  338
Incrementer Id=3 Name=Incr.:  339
Incrementer Id=3 Name=Incr.:  340
Incrementer Id=3 Name=Incr.:  341
Incrementer Id=3 Name=Incr.:  342
Incrementer Id=3 Name=Incr.:  343
Incrementer Id=3 Name=Incr.:  344
Incrementer Id=3 Name=Incr.:  345
Incrementer Id=3 Name=Incr.:  346
Incrementer Id=3 Name=Incr.:  347
Incrementer Id=3 Name=Incr.:  348
Incrementer Id=3 Name=Incr.:  349
Incrementer Id=3 Name=Incr.:  350
Incrementer Id=3 Name=Incr.:  351
Incrementer Id=3 Name=Incr.:  352
Incrementer Id=3 Name=Incr.:  353
Incrementer Id=3 Name=Incr.:  354
Incrementer Id=3 Name=Incr.:  355
Incrementer Id=3 Name=Incr.:  356
Incrementer Id=3 Name=Incr.:  357
Incrementer Id=3 Name=Incr.:  358
Incrementer Id=3 Name=Incr.:  359
Incrementer Id=3 Name=Incr.:  360
Incrementer Id=3 Name=Incr.:  361
Incrementer Id=3 Name=Incr.:  362
Incrementer Id=3 Name=Incr.:  363
Incrementer Id=3 Name=Incr.:  364
Incrementer Id=3 Name=Incr.:  365
Incrementer Id=3 Name=Incr.:  366
Incrementer Id=3 Name=Incr.:  367
Incrementer Id=3 Name=Incr.:  368
Incrementer Id=3 Name=Incr.:  369
Incrementer Id=3 Name=Incr.:  370
Incrementer Id=3 Name=Incr.:  371
Incrementer Id=3 Name=Incr.:  372
Incrementer Id=3 Name=Incr.:  373
Incrementer Id=3 Name=Incr.:  374
Incrementer Id=3 Name=Incr.:  375
Incrementer Id=3 Name=Incr.:  376
Incrementer Id=3 Name=Incr.:  377
Incrementer Id=3 Name=Incr.:  378
Incrementer Id=3 Name=Incr.:  379
Incrementer Id=3 Name=Incr.:  380
Incrementer Id=3 Name=Incr.:  381
Incrementer Id=3 Name=Incr.:  382
Incrementer Id=3 Name=Incr.:  383
Incrementer Id=3 Name=Incr.:  384
Incrementer Id=3 Name=Incr.:  385
Incrementer Id=3 Name=Incr.:  386
Incrementer Id=3 Name=Incr.:  387
Incrementer Id=3 Name=Incr.:  388
Incrementer Id=3 Name=Incr.:  389
Incrementer Id=3 Name=Incr.:  390
Incrementer Id=3 Name=Incr.:  391
Incrementer Id=3 Name=Incr.:  392
Incrementer Id=3 Name=Incr.:  393
Incrementer Id=3 Name=Incr.:  394
Incrementer Id=3 Name=Incr.:  395
Incrementer Id=3 Name=Incr.:  396
Incrementer Id=3 Name=Incr.:  397
Incrementer Id=3 Name=Incr.:  398
Incrementer Id=3 Name=Incr.:  399
Incrementer Id=3 Name=Incr.:  400
Incrementer Id=3 Name=Incr.:  401
Incrementer Id=3 Name=Incr.:  402
Incrementer Id=3 Name=Incr.:  403
Incrementer Id=3 Name=Incr.:  404
Incrementer Id=3 Name=Incr.:  405
Incrementer Id=3 Name=Incr.:  406
Incrementer Id=3 Name=Incr.:  407
Incrementer Id=3 Name=Incr.:  408
Incrementer Id=3 Name=Incr.:  409
Incrementer Id=3 Name=Incr.:  410
Incrementer Id=3 Name=Incr.:  411
Incrementer Id=3 Name=Incr.:  412
Incrementer Id=3 Name=Incr.:  413
Incrementer Id=3 Name=Incr.:  414
Incrementer Id=3 Name=Incr.:  415
Incrementer Id=3 Name=Incr.:  416
Incrementer Id=3 Name=Incr.:  417
Incrementer Id=3 Name=Incr.:  418
Incrementer Id=3 Name=Incr.:  419
Incrementer Id=3 Name=Incr.:  420
Incrementer Id=3 Name=Incr.:  421
Incrementer Id=3 Name=Incr.:  422
Incrementer Id=3 Name=Incr.:  423
Incrementer Id=3 Name=Incr.:  424
Incrementer Id=3 Name=Incr.:  425
Incrementer Id=3 Name=Incr.:  426
Incrementer Id=3 Name=Incr.:  427
Incrementer Id=3 Name=Incr.:  428
Incrementer Id=3 Name=Incr.:  429
Incrementer Id=3 Name=Incr.:  430
Incrementer Id=3 Name=Incr.:  431
Incrementer Id=3 Name=Incr.:  432
Incrementer Id=3 Name=Incr.:  433
Incrementer Id=3 Name=Incr.:  434
Incrementer Id=3 Name=Incr.:  435
Incrementer Id=3 Name=Incr.:  436
Incrementer Id=3 Name=Incr.:  437
Incrementer Id=3 Name=Incr.:  438
Incrementer Id=3 Name=Incr.:  439
Incrementer Id=3 Name=Incr.:  440
Incrementer Id=3 Name=Incr.:  441
Incrementer Id=3 Name=Incr.:  442
Incrementer Id=3 Name=Incr.:  443
Incrementer Id=3 Name=Incr.:  444
Incrementer Id=3 Name=Incr.:  445
Incrementer Id=3 Name=Incr.:  446
Incrementer Id=3 Name=Incr.:  447
Incrementer Id=3 Name=Incr.:  448
Incrementer Id=3 Name=Incr.:  449
Incrementer Id=3 Name=Incr.:  450
Incrementer Id=3 Name=Incr.:  451
Incrementer Id=3 Name=Incr.:  452
Incrementer Id=3 Name=Incr.:  453
Incrementer Id=3 Name=Incr.:  454
Incrementer Id=3 Name=Incr.:  455
Incrementer Id=3 Name=Incr.:  456
Incrementer Id=3 Name=Incr.:  457
Incrementer Id=3 Name=Incr.:  458
Incrementer Id=3 Name=Incr.:  459
Incrementer Id=3 Name=Incr.:  460
Incrementer Id=3 Name=Incr.:  461
Incrementer Id=3 Name=Incr.:  462
Incrementer Id=3 Name=Incr.:  463
Incrementer Id=3 Name=Incr.:  464
Incrementer Id=3 Name=Incr.:  465
Incrementer Id=3 Name=Incr.:  466
Incrementer Id=3 Name=Incr.:  467
Incrementer Id=3 Name=Incr.:  468
Incrementer Id=3 Name=Incr.:  469
Incrementer Id=3 Name=Incr.:  470
Incrementer Id=3 Name=Incr.:  471
Incrementer Id=3 Name=Incr.:  472
Incrementer Id=3 Name=Incr.:  473
Incrementer Id=3 Name=Incr.:  474
Incrementer Id=3 Name=Incr.:  475
Incrementer Id=3 Name=Incr.:  476
Incrementer Id=3 Name=Incr.:  477
Incrementer Id=3 Name=Incr.:  478
Incrementer Id=3 Name=Incr.:  479
Incrementer Id=3 Name=Incr.:  480
Incrementer Id=3 Name=Incr.:  481
Incrementer Id=3 Name=Incr.:  482
Incrementer Id=3 Name=Incr.:  483
Incrementer Id=3 Name=Incr.:  484
Incrementer Id=3 Name=Incr.:  485
Incrementer Id=3 Name=Incr.:  486
Incrementer Id=3 Name=Incr.:  487
Incrementer Id=3 Name=Incr.:  488
Incrementer Id=3 Name=Incr.:  489
Incrementer Id=3 Name=Incr.:  490
Incrementer Id=3 Name=Incr.:  491
Incrementer Id=3 Name=Incr.:  492
Incrementer Id=3 Name=Incr.:  493
Incrementer Id=3 Name=Incr.:  494
Incrementer Id=3 Name=Incr.:  495
Incrementer Id=3 Name=Incr.:  496
Incrementer Id=3 Name=Incr.:  497
Incrementer Id=3 Name=Incr.:  498
Incrementer Id=3 Name=Incr.:  499
Incrementer Id=3 Name=Incr.:  500


 */
