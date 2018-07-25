using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;





namespace SortPaginateFilter.Models
{





    public class FilterViewModel
    {
        public FilterViewModel(List<Company> companies, int? company, string name)
        {
            // ������������� ��������� �������, ������� �������� ������� ����
            companies.Insert(0, new Company {Name = "���", Id = 0});
            Companies = new SelectList(companies, "Id", "Name", company);
            SelectedCompany = company;
            SelectedName = name;
        }





        public SelectList Companies { get; private set; } // ������ ��������
        public int? SelectedCompany { get; private set; } // ��������� ��������
        public string SelectedName { get; private set; } // ��������� ���
    }





}