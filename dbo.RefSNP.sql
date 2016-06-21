CREATE TABLE [dbo].[RefSNP] (
    [chrom_num]             NCHAR (10)  NOT NULL,
    [chrom_position]        NCHAR (30)  NOT NULL,
    [ref_nuc]               NCHAR (10)    NOT NULL,
    [var_nuc]               NCHAR (10)    NOT NULL,
    [rsid]                  NCHAR (30)  NULL,
    [clinical_significance] NCHAR (50)  NULL,
    [population_diversity]  NCHAR (50)  NULL,
    [maf]                   NCHAR (100) NULL,
    [chrom_sample_count]    NCHAR (15)  NULL,
    [alleles]               NCHAR (50)  NULL,
    [alleles_percentage]    NCHAR (50)  NULL
);

