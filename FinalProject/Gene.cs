using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /*
     * Gene class holds the gene details.
     * Main purpose - easy transfer of gene details
     */
    public class Gene
    {
        private string _name;
        private string _chrom;
        private char _strand;
        private int _cdsStart;
        private int _cdsEnd;
        private int[] _exonStarts;
        private int[] _exonEnds;

        //First constructor - get raw gene data, calculate and fix the exons positions.
        public Gene(string name, string chrom, char strand, int cdsStart, int cdsEnd, int[] exonStarts, int[] exonEnds)
        {
            _name = name;
            _chrom = chrom;
            _strand = strand;
            _cdsStart = cdsStart;
            _cdsEnd = cdsEnd;
            fixExonStartEnd(exonStarts, exonEnds);
        }
        //Second constructor - get gene data from local database, exons allready fixed.
        public Gene(string name, string chrom, char strand, int[] exonStarts, int[] exonEnds)
        {
            _name = name;
            _chrom = chrom;
            _strand = strand;
            _exonStarts = exonStarts;
            _exonEnds = exonEnds;
        }

        //Fix the start postion and the end position of gene that received for easy later calculation.
        private void fixExonStartEnd(int[] exonStarts, int[] exonEnds)
        {
            List<int> tempStarts = new List<int>();
            List<int> tempEnds = new List<int>();
            for (int i = 0; i < exonStarts.Length; i++)
            {
                if (_cdsStart > exonEnds[i])
                    continue;
                if (_cdsStart >= exonStarts[i] && _cdsStart <= exonEnds[i])
                {
                    tempStarts.Add(_cdsStart);
                    if (_cdsEnd >= exonStarts[i] && _cdsEnd <= exonEnds[i])
                    {
                        tempEnds.Add(_cdsEnd);
                        break;
                    }
                    else
                        tempEnds.Add(exonEnds[i]);
                }
                else
                {
                    tempStarts.Add(exonStarts[i]);
                    if (_cdsEnd >= exonStarts[i] && _cdsEnd <= exonEnds[i])
                    {
                        tempEnds.Add(_cdsEnd);
                        break;
                    }
                    else
                        tempEnds.Add(exonEnds[i]);
                }
            }
            _exonStarts = tempStarts.ToArray();
            _exonEnds = tempEnds.ToArray();
        }

        //Calculate the offset in the codon, get index and return 0 for first place,1 for second place, 2 for third place, -1 for non codon position 
        public int getOffsetInCodon(int index)
        {
            int lengthToIndex = getLengthToIndex(index);
            if (lengthToIndex > -1)
            {
                if (_strand.Equals('+'))
                    return (lengthToIndex - 1) % 3;
                else
                {
                    int negOffset = (lengthToIndex) % 3;
                    if (negOffset == 2)
                        return 0;
                    else if (negOffset == 0)
                        return 2;
                    else
                        return 1;
                }
            }
            return -1;
        }

        //return the length from the start of the gene to index, for both '-' and '+' strand
        public int getLengthToIndex(int index)
        {
            int lengthToIndex = 0;
            bool found = false;
            if (_strand.Equals('+'))
            {
                for (int i = 0; i < _exonStarts.Length; i++)
                {
                    if (index >= _exonStarts[i] && index <= _exonEnds[i])
                    {

                        found = true;
                        lengthToIndex += index - _exonStarts[i];
                        break;
                    }
                    else
                    {
                        lengthToIndex += _exonEnds[i] - _exonStarts[i];
                    }
                }
            }
            else
            {
                for (int i = _exonStarts.Length - 1; i >= 0; i--)
                {
                    if (index >= _exonStarts[i] && index <= _exonEnds[i])
                    {
                        found = true;
                        lengthToIndex += _exonEnds[i] - index;
                        break;
                    }
                    else
                    {
                        lengthToIndex += _exonEnds[i] - _exonStarts[i];
                    }
                }
            }
            if (found)
                return lengthToIndex;
            return -1;
        }

        public int[] ExonStarts { get { return _exonStarts; } }
        public int[] ExonEnds { get { return _exonEnds; } }
        public char Strand { get { return _strand; } }
    }
}
