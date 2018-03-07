select * ,[SBRK] + [SLHIPA] as PośrednioProdukcyjne,[SLHDPA] as BezpośrednioProdukcyjne,
            [SOT] as Nadgodziny,[SLT] as Nieobecności,[SBRK] + [SLHIPA] + [SLHDPA] as Wszystkie,([SBRK] + [SLHIPA])/([SBRK] + [SLHIPA] + [SLHDPA]) DOIi
            from GodzinyKontowaneP_Podsumowanie,
			(select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null ) as periodsProcedure						
			where xIPT = 1 and x=2 and Period_Year = periodsProcedure.Parametr;