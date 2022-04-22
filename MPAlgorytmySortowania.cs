using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularze_nawigacja
{
    class MPAlgorytmySortowania
    {
        static public ushort mpSelectSort(ref int[] mpT, ushort mpL)
        {
            return 0;
        }
        static public ushort mpInsertionSort(ref int[] mpT, ushort mpL)
        {
            return 0;
        }
        static public ushort mpQuickSort(ref int[] mpT, ushort mpD, ushort mpG)
        {
            return 0;
        }
        public static int mpMergeSort(ref int[] mpT, int mpD, int mpG)
        {
            // d - dolny index
            // g - górny index
            int mpLicznikOD = 0; // licznik operacji dominujących
            // sprawdzenie warunku zakończenia rekurencji (warunku brzegowego)
            if (mpD == mpG)
                // tablica do sortowanie jest jednoelementowa, więc nie można jej posortować
                return 0;
            // tablica ma co najmniej dwa elementy i można ją podzielić na dwie tablice
            int mpS = (mpD + mpG) / 2; // indeks podziału tablicy mpT na dwie:
                                       // mpT[mpD, mpS] i mpT[mpS + 1, mpG]
                                       // wywołanie rekurencyjnej metody mpMergeSort dla obu tablic
            mpLicznikOD += mpMergeSort(ref mpT, mpD, mpS);
            mpLicznikOD += mpMergeSort(ref mpT, mpS + 1, mpG);
            // połączenie w obu posortowanych tablic
            int mpI = mpS; int mpJ = mpS + 1; // zmienne pomocnicze do iteracji
            while (mpD <= mpI && mpJ <= mpG)
            {
                mpLicznikOD++; // zwiększenie licznika o jeden
                if (mpT[mpD] < mpT[mpJ])
                    mpD++;
                else
                {
                    // wstawienie na pozycję mpD elementu mpT[mpJ] 
                    int mpPrzestawianyElement = mpT[mpJ];
                    for (int mpK = mpJ - 1; mpK >= mpD; mpK--)
                        mpT[mpK + 1] = mpT[mpK];
                    mpT[mpD] = mpPrzestawianyElement;
                    // uaktualnienie indexów
                    mpD++; mpI++; mpJ++;
                }
            }
            return mpLicznikOD;
        }
        public static int mpMergeSortProjekt(ref string[] mpT, int mpD, int mpG)
        {
            int mpLicznik = 0; // licznik operacji dominujących
            if (mpD == mpG) // sprawdzenie czy tablica ma więcej niz jeden element
                return 0; // jeśli tak, zwracana jest ilość operacaji dominujących równa 0
                          // i sortowanie się nie wykonuje (gdyż nie jest to możliwe)
            int mpS = (mpD + mpG) / 2; // zdefiniowanie zmiennej przechowującej środkowy indeks tablicy
            // wywołanie metody mpMergeSortProjekt dla obu połówek tablicy
            mpLicznik += mpMergeSortProjekt(ref mpT, mpD, mpS);
            mpLicznik += mpMergeSortProjekt(ref mpT, mpS + 1, mpG);
            int mpI = mpS; int mpJ = mpS + 1;
            while (mpD <= mpI && mpJ <= mpG)
            {
                mpLicznik++; // zwiększenie licznika o jeden
                if (String.Compare(mpT[mpD], mpT[mpJ]) < 0)
                    mpD++;
                else
                {
                    string mpPrzestawianyElement = mpT[mpJ];
                    for (int mpK = mpJ - 1; mpK >= mpD; mpK--)
                        mpT[mpK + 1] = mpT[mpK];
                    mpT[mpD] = mpPrzestawianyElement;
                    mpD++; mpI++; mpJ++;
                }
            }
            return mpLicznik;
        }
        public static int mpBucketSortProjekt(ref string[] mpT, int mpN)
        {
            if (mpT.Length <= 0)
                return 0;
            int Licznik = 0;
            List<string>[] mpKubełki = new List<string>[mpN];

            for(int mpI = 0; mpI < mpN; mpI++)
                mpKubełki[mpI] = new List<string>(); Licznik++;
            for (int mpI = 0; mpI < mpN; mpI++)
                mpKubełki[mpT[mpI].GetHashCode() / mpN].Add(mpT[mpI]); Licznik++;
            for (int mpI = 0; mpI < mpN; mpI++)
                mpKubełki[mpI].Sort(); Licznik++;

            int mpIndex = 0;
            for (int mpI = 0; mpI < mpN; mpI++)
                for (int mpJ = 0; mpJ < mpKubełki[mpI].Count; mpJ++)
                    mpT[mpIndex++] = mpKubełki[mpI][mpJ]; Licznik++;
            Console.WriteLine(Licznik);
            return 4 * mpN;
        }
    }
}
