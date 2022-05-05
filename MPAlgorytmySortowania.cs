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
            if (mpD == mpG) // sprawdzenie czy tablica ma więcej niz jeden element
                return 0; // jeśli tak, zwracana jest ilość operacaji dominujących równa 0
                          // i sortowanie się nie wykonuje (gdyż nie jest to możliwe)
            int mpLicznik = 0; // licznik operacji dominujących
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

        //  sortowanie tablicy string za pomocą algorytmu BucketSort
        public static int mpBucketSortString(ref string[] mpT,short mpZnakHashCode)
        {
            // jeśli tablica ma co najmniej jeden element, sortowanie nie jest wykonywane
            if (mpT.Length <= 1)
                return 0;
            int mpLicznik = 0; // licznik operacji dominujących
            // utworzenie listy kubełków
            List<string>[] mpKubelki = new List<string>[mpT.Length];
            for (int mpI = 0; mpI < mpT.Length; mpI++)
                mpKubelki[mpI] = new List<string>(); mpLicznik++;
            // umieszczenie elementów tablicy w kubłekach
            for (int mpI = 0; mpI < mpT.Length; mpI++)
            {
                double mpHashCode = mpT[mpI].GetHashCode() * mpZnakHashCode;
                // zamiana mpHashCode w ułamek bez elementu całkowitego
                while (mpHashCode > 1)
                    mpHashCode /= 10;
                mpKubelki[(int)(mpHashCode * mpT.Length)].Add(mpT[mpI]); 
                mpLicznik++;
            }
            // przesortowanie kubełków
            for (int mpI = 0; mpI < mpT.Length; mpI++)
                mpKubelki[mpI].Sort(); mpLicznik++;

            // umieszczenie zawartości kubełków w tablicy
            int mpIndex = 0;
            for (int mpI = 0; mpI < mpT.Length; mpI++)
                for (int mpJ = 0; mpJ < mpKubelki[mpI].Count; mpJ++)
                    mpT[mpIndex++] = mpKubelki[mpI][mpJ]; mpLicznik++;
            return mpLicznik;
        }

        // metoda do sortowania za pomocą algorytmu BucketSort stworzona na potrzeby projektu
        public static int mpBucketSortProjekt(ref string[] mpT)
        {
            // jeśli tablica ma co najmniej jeden element, sortowanie nie jest wykonywane
            if (mpT.Length <= 1)
                return 0;
            int mpLicznik = 0; // licznik operacji dominujących
            List<string> mpHashCodeUjemnyLista = new List<string>(); // lista przechowująca elementy tablicy o ujemnym HashCodzie
            List<string> mpHashCodeDodatniLista = new List<string>(); // lista przechowująca elementy tablicy o dodatnim HashCodzie
            ushort mpI; // zmienna pomocnicza do iteracji
            // przypisanie elementów do odpowiedniej listy
            for (mpI = 0; mpI < mpT.Length; mpI++)
                if(mpT[mpI].GetHashCode() < 0) 
                    mpHashCodeUjemnyLista.Add(mpT[mpI]);
                else
                    mpHashCodeDodatniLista.Add(mpT[mpI]);
            // przeniesienie list do tablic
            string[] mpHashCodeUjemnyTablica = mpHashCodeUjemnyLista.ToArray();
            string[] mpHashCodeDodatniTablica = mpHashCodeDodatniLista.ToArray();
            // przesortowanie tablic
            mpLicznik += mpBucketSortString(ref mpHashCodeUjemnyTablica, -1);
            mpLicznik += mpBucketSortString(ref mpHashCodeDodatniTablica, 1);
            Array.Reverse(mpHashCodeUjemnyTablica); // odwórcenie tablicy z elementami ujemnymi
            // umieszczenie posortowanych elementów w tablicy wejściowej
            for(mpI = 0; mpI < mpHashCodeUjemnyTablica.Length; mpI++)  
                mpT[mpI]= mpHashCodeUjemnyTablica[mpI];
            for(; mpI<mpT.Length;mpI++)
                mpT[mpI]=mpHashCodeDodatniTablica[mpI - mpHashCodeUjemnyTablica.Length];

            return mpLicznik;
        }
    }
}
