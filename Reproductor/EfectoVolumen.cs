using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Reproductor
{
    class EfectoVolumen : ISampleProvider
    {
        private ISampleProvider fuente;
        private float volumen;

        public EfectoVolumen(ISampleProvider fuente)
        {
            this.fuente = fuente;
            volumen = 1.0f;
        }

        public float volumen
        {
            get
            {
                return volumen;
            }
            set
            {
                if(value < 0)
                {
                    volumen = 0;
                }
                else if(value > 1)
                {
                    volumen = 1;
                }
                else
                {
                    volumen = value;
                }
            }
        }

        public WaveFormat Waveformt
        {
            get
            {
                return fuente.WaveFormat;
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int read = fuente.Read(buffer, offset, count);

            //Aplicar el efecto
            for (int i = 0; i < read; i++)
            {
                buffer[i + ofset] *= volumen;
            }

            return read;
        }
    }
}
