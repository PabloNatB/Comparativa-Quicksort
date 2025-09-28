# QuickSort - Divide and Conquer

Proyecto hecho por Alexis Raciel Ibarra Garnica y Pablo Natera Bravo

Se hizo una comparativa entre el famoso algoritmo Quicksort y


## Descripción
QuickSort es un algoritmo de ordenación que usa Divide and Conquer.  

### Pasos principales del algoritmo:
1. Si la longitud del arreglo es menor a dos se retorna el elemento inmediatamente, ya que se considera el caso base.
2. Si la longitud es 2 o más se escoge un pivote (hay distintas técnicas para esto).
3. Reordena el arreglo hasta que los elementos menores al pivote estén a la izquierda y los mayores a la derecha.
4. Aplica estos pasos a las dos mitades que quedan a la derecha e izquierda de manera recursiva hasta llegar al caso base.


## Complejidad
- **Mejor caso:** Θ(n log n)  
- **Caso promedio:** Θ(n log n)  
- **Peor caso:** O(n²) (cuando el pivote no se escoge bien)
