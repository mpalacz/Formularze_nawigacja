using System;
using System.Collections.Generic;

namespace Formularze_nawigacja
{
    class MPAlgorytmySortowania
    {
        static public ushort mpSelectSort(ref int[] mpT, ushort mpL)
        {
            ushort mpK; // indeks położenia elementu najmniejszego
            int mpPomocnicza; // zmienna przechowująca element tablicy
            ushort mpLicznik = 0; // licznik operacji dominujących
            for (ushort mpI = 0; mpI < mpL; mpI++)
            {
                mpK = mpI; // ustawienie pierwszego elementu jako najmniejszy
                for (ushort mpJ = (ushort)(mpI + 1); mpJ < mpL; mpJ++)
                {
                    // zwiększenie licznika o jeden
                    mpLicznik++;
                    // jeżeli zostanie znajleziony mniejszy element, jego indeks zostaje zapisany
                    if (mpT[mpK] == mpT[mpJ])
                        mpK = mpJ;
                }
                // zamiana elementów tablicy
                mpPomocnicza = mpT[mpI];
                mpT[mpI] = mpT[mpK];
                mpT[mpK] = mpPomocnicza;
            }
            return mpLicznik;
        }
        static public ushort mpInsertionSort(ref int[] mpT, ushort mpN)
        {
            ushort mpLicznik = 0; // licznik operacji dominujących
            ushort mpK; // indeks położenia elemmentu w nieuporządkowanej części tablicy
            int mpPomocnicza; // zmienna pomocnicza do przechowania elementu tablicy
            for (ushort mpI = 1; mpI < mpN; mpI++)
            {
                // zapisanie elementu tablicy i jego wykresu w zmiennej
                mpPomocnicza = mpT[mpI];
                mpK = mpI;
                while (mpK > 0 && mpPomocnicza < mpT[mpK - 1])
                {
                    // zwiększenie licznika
                    mpLicznik++;
                    // przepisanie elementu uporządkowanej częsci tablicy
                    mpT[mpK] = mpT[mpK - 1];
                    // przesunięcie w lewo uporządkowanej części tablicy
                    mpK--;
                }
                mpLicznik++;
                mpT[mpK] = mpPomocnicza;
            }
            return mpLicznik;
        }
        static public ushort mpQuickSort(ref int[] mpT, ushort mpD, ushort mpG)
        {
            ushort mpI = mpD; // d - dolny indeks sortowanej tablicy
            ushort mpJ = mpG; // g - górny indeks sortowanej tablicy
            int mpRobocza; // zmienna pomocnicza przechowująca element tablicy
            ushort mpLicznik = 0; // licznik operacji dominujących
            if (mpD == mpG) // nie wykonuje się sortowania tablicy jednoelelentowej
                return 1;
            int mpS = (mpD + mpG) / 2; // środek tablicy
            int mpX = mpT[mpS]; // element środkowy
            do // przestawienie elementów tablicy wzgędem elementu śordkowego
            {
                // analizowanie lewej strony
                while (mpI < mpG && mpT[mpI] < mpX)
                { mpI++; mpLicznik++; }
                mpLicznik++;
                // analizowanie prawej strony
                while (mpJ > mpD && mpT[mpJ] > mpX) { mpJ--; mpLicznik++; }
                mpLicznik++;
                // wymiana elementów tablicy między mpI, a mpJ
                if (mpI <= mpJ)
                {
                    mpRobocza = mpT[mpI];
                    mpT[mpI] = mpT[mpJ];
                    mpT[mpJ] = mpRobocza;
                    mpI++;
                    mpJ++;
                }
            } while (mpI < mpJ);
            // rekurencyjne wywałanie metody
            if (mpD < mpJ) mpLicznik += mpQuickSort(ref mpT, mpD, (ushort)(mpS - 1));
            if (mpI < mpG) mpLicznik += mpQuickSort(ref mpT, mpI, (ushort)(mpS + 1));
            return mpLicznik;

        }
        static public ushort mpBubbleSort(ref int[] mpT)
        {
            ushort mpLicznik = 0; // licznik operacji dominujących
            // dwukrotnej iterowanie przez tablice
            for (int mpI = 0; mpI < mpT.Length - 1; mpI++)
                for (int mpJ = 0; mpJ < mpT.Length - mpI - 1; mpJ++)
                    // jeśli elementy będące obok siebie są w złej kolejności
                    if (mpT[mpJ] > mpT[mpJ + 1])
                    {
                        // następuje ich zamiana
                        int mpPomocnicza = mpT[mpJ];
                        mpT[mpJ] = mpT[mpJ + 1];
                        mpT[mpJ + 1] = mpPomocnicza;
                        mpLicznik++; // zwiększenie licznika
                    }
            return mpLicznik;
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
        public static int mpBucketSortString(ref string[] mpT, short mpZnakHashCode)
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
                if (mpT[mpI].GetHashCode() < 0)
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
            for (mpI = 0; mpI < mpHashCodeUjemnyTablica.Length; mpI++)
                mpT[mpI] = mpHashCodeUjemnyTablica[mpI];
            for (; mpI < mpT.Length; mpI++)
                mpT[mpI] = mpHashCodeDodatniTablica[mpI - mpHashCodeUjemnyTablica.Length];

            return mpLicznik;
        }
    }
}
