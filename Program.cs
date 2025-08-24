using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== CAMPAÑA NACIONAL DE VACUNACIÓN COVID-19 ===\n");

        // Paso 1: Registro de los 500 ciudadanos
        HashSet<string> ciudadanos = GenerarCiudadanos(500);

        // Paso 2: Grupo aleatorio de vacunados con Pfizer
        HashSet<string> grupoPfizer = SeleccionarVacunados(ciudadanos, 75);

        // Paso 3: Grupo aleatorio de vacunados con AstraZeneca
        HashSet<string> grupoAstra = SeleccionarVacunados(ciudadanos, 75);

        // Paso 4: Operaciones de conjuntos
        var todosVacunados = new HashSet<string>(grupoPfizer);
        todosVacunados.UnionWith(grupoAstra);

        var noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(todosVacunados);

        var conAmbas = new HashSet<string>(grupoPfizer);
        conAmbas.IntersectWith(grupoAstra);

        var soloPfizer = new HashSet<string>(grupoPfizer);
        soloPfizer.ExceptWith(grupoAstra);

        var soloAstra = new HashSet<string>(grupoAstra);
        soloAstra.ExceptWith(grupoPfizer);

        // Paso 5: Mostrar resultados
        Console.WriteLine("Total ciudadanos: " + ciudadanos.Count);
        Console.WriteLine("Vacunados Pfizer: " + grupoPfizer.Count);
        Console.WriteLine("Vacunados AstraZeneca: " + grupoAstra.Count);
        Console.WriteLine("Vacunados con ambas: " + conAmbas.Count);
        Console.WriteLine("Solo Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Solo AstraZeneca: " + soloAstra.Count);
        Console.WriteLine("No vacunados: " + noVacunados.Count);
    }

    // ---------------- Métodos auxiliares ----------------
    static HashSet<string> GenerarCiudadanos(int cantidad)
    {
        var set = new HashSet<string>();
        for (int i = 1; i <= cantidad; i++)
        {
            set.Add("Persona_" + i);
        }
        return set;
    }

    static HashSet<string> SeleccionarVacunados(HashSet<string> poblacion, int cantidad)
    {
        var seleccion = new HashSet<string>();
        Random rnd = new Random();

        var lista = new List<string>(poblacion);
        while (seleccion.Count < cantidad)
        {
            int idx = rnd.Next(lista.Count);
            seleccion.Add(lista[idx]);
        }
        return seleccion;
    }
}