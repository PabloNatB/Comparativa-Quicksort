import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
from pathlib import Path
import os

script_path = Path(__file__).parents[0]

#parent directory
parent_directory = script_path.parent
abs_path = parent_directory / 'Qsort' / 'bin' / 'Debug' / 'net8.0'

#Experimento 1

## Experimento 1A
df_exp1A = pd.read_csv(abs_path /  'experimento1A.csv')

plt.figure(figsize=(10, 6))
plt.scatter(df_exp1A.n, df_exp1A['QS_v1_Comparaciones'], 
            label='Quicksort Clásico', color='red', alpha=0.7, s=50)
plt.scatter(df_exp1A.n, df_exp1A['QS_v2_Comparaciones'], 
            label='Quicksort Optimizado', color='blue', alpha=0.7, s=50)

plt.title('Comparativa Quicksorts en Arreglos Aleatorios', fontsize=14, fontweight='bold')
plt.ylabel('Número de Comparaciones', fontsize=12)
plt.xlabel('Longitud del Arreglo', fontsize=12)

plt.legend(fontsize=11)
plt.grid(True, alpha=0.3)

plt.tight_layout()
plt.savefig( 'Exp1A.png', dpi=600, bbox_inches='tight')
plt.clf()

## Experimento 2A
df_exp1B = pd.read_csv(abs_path / 'experimento1B.csv')


plt.figure(figsize=(10, 6))

plt.scatter(x=df_exp1B.n, y=df_exp1B['QS_v1_Comparaciones'],  label='Quicksort Clásico', color='red', marker='o', s=60, alpha=0.8, edgecolors='black')
plt.scatter(x=df_exp1B.n, y=df_exp1B['QS_v2_Comparaciones'],   label='Quicksort Optimizado', color='blue', marker='s', s=60, alpha=0.8, edgecolors='black')

# Curvas 
plt.plot(df_exp1B.n, [(x**2)/2 for x in df_exp1B.n], 
         label=r'$O(n^2)$', c='black', linestyle='--', linewidth=2, alpha=0.6)
plt.plot(df_exp1B.n, [x*np.log2(x) for x in df_exp1B.n], 
         label=r'$O(n\cdot \log {n})$', c='black', linestyle='-.', linewidth=2, alpha=0.6)


plt.title('Comparativa Quicksorts en Arreglos Ordenados\n(Impacto de la Mediana de 3)', 
          fontsize=14, fontweight='bold')
plt.ylabel('Número de Comparaciones', fontsize=12)
plt.xlabel('Longitud del Arreglo', fontsize=12)

plt.legend(fontsize=11, frameon=True, fancybox=True, shadow=True)
plt.grid(True, alpha=0.3)
plt.xscale('log')
plt.yscale('log')
plt.xticks(fontsize=11)
plt.yticks(fontsize=11)

plt.tight_layout()
plt.savefig( 'Exp1B.png', dpi=600, bbox_inches='tight')
plt.clf()
#Experimento 2

## Experimento 2A
df_exp2A = pd.read_csv(abs_path / 'experimento2A.csv')

plt.figure(figsize=(12, 8))


colors = ['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd']
markers = ['o', 's', '^', 'D', 'v']
algorithms = ['QS_v2_Comparaciones', 'Bubble_Comparaciones', 'FlagBubble_Comparaciones', 
              'Insertion_Comparaciones', 'Selection_Comparaciones']
labels = ['Quicksort Optimizado', 'Bubblesort', 'Flag Bubblesort', 'Insertionsort', 'Selectionsort']
x_2 = [(x**2)/2 for x in df_exp2A.n]
nlogn = [x*np.log2(x) for x in df_exp2A.n]

for i, (algo, label) in enumerate(zip(algorithms, labels)):
    plt.scatter(x=df_exp2A.n, y=df_exp2A[algo], 
                label=label, 
                color=colors[i],
                marker=markers[i],
                s=60,           
                alpha=0.7,     
                edgecolors='black',  
                linewidth=0.5)

plt.plot(df_exp2A.n, x_2, 
                label = r'$O(n^2)$', c = 'black' , linestyle = '--')
plt.plot(df_exp2A.n, nlogn, 
                label = r'$O(n\cdot \log{n)}$', c = 'black' , linestyle = '-.' )


plt.title('Comparativa de Algoritmos de Ordenamiento\n(Arreglos Aleatorios)', 
          fontsize=14, fontweight='bold', pad=20)

plt.ylabel('Número de Comparaciones', fontsize=15)
plt.xlabel('Longitud del Arreglo', fontsize=15)


plt.legend(bbox_to_anchor=(0, 1), loc='upper left', frameon=True, 
           fancybox=True, shadow=True, fontsize=15)

plt.grid(True, alpha=0.3, linestyle='-', linewidth=2)
plt.grid(True, which='minor', alpha=0.2, linestyle='--', linewidth=0.3)

plt.xscale('log')
plt.yscale('log')

plt.xticks(fontsize=12)
plt.yticks(fontsize=12)

plt.tight_layout()

plt.savefig('Exp2A.png', dpi=600, bbox_inches='tight')
plt.clf()
## Experimento 2B
df_exp2B = pd.read_csv(abs_path / 'experimento2B.csv')


plt.figure(figsize=(12, 8))


colors = ['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd']
markers = ['o', 's', '^', 'D', 'v']
algorithms = ['QS_v2_Comparaciones', 'Bubble_Comparaciones', 'FlagBubble_Comparaciones', 
              'Insertion_Comparaciones', 'Selection_Comparaciones']
labels = ['Quicksort Optimizado', 'Bubblesort', 'Flag Bubblesort', 'Insertionsort', 'Selectionsort']

# Curvas 
x_2 = [(x**2)/2 for x in df_exp2B.n]  
n = [x for x in df_exp2B.n]       
nlogn = [x*np.log2(x) for x in df_exp2B.n]

# Scatter plot
for i, (algo, label) in enumerate(zip(algorithms, labels)):
    plt.scatter(x=df_exp2B.n, y=df_exp2B[algo], 
                label=label, 
                color=colors[i],
                marker=markers[i],
                s=60,
                alpha=0.7,
                edgecolors='black',
                linewidth=0.5)

# Curvas de referencia
plt.plot(df_exp2B.n, x_2, label=r'$O(n^2)$', c='black', linestyle='--', linewidth=2, alpha=0.8)
plt.plot(df_exp2B.n, nlogn, label=r'$O(n\cdot \log n)$', c='black', linestyle='-.', linewidth=2, alpha=0.8)
plt.plot(df_exp2B.n, n, label=r'$O(n)$', c='black', linestyle=':', linewidth=2, alpha=0.8)


plt.title('Comportamiento de Algoritmos en Arreglos Ordenados', 
          fontsize=16, fontweight='bold', pad=20)
plt.ylabel('Número de Comparaciones', fontsize=14)
plt.xlabel('Longitud del Arreglo', fontsize=14)

plt.legend(bbox_to_anchor=(0, 1), loc='upper left', frameon=True, 
           fancybox=True, shadow=True, fontsize=12)

plt.grid(True, alpha=0.3)
plt.xscale('log')
plt.yscale('log')
plt.xticks(fontsize=11)
plt.yticks(fontsize=11)

plt.tight_layout()
plt.savefig('Exp2B.png', dpi=600, bbox_inches='tight')
plt.clf()