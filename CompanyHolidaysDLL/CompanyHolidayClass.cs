/* Title:           Company Holiday Class
 * Date:            1-17-19
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for Company Holidays */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace CompanyHolidaysDLL
{
    public class CompanyHolidayClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        CompanyHolidaysDataSet aCompanyHolidaysDataSet;
        CompanyHolidaysDataSetTableAdapters.companyholidaysTableAdapter aCompanyHolidaysTableAdapter;

        InsertCompanyHolidayEntryTableAdapters.QueriesTableAdapter aInsertCompanyHolidayTableAdapter;

        FindCompanyHolidayByDateDataSet aFindCompanyHolidayByDateDataSet;
        FindCompanyHolidayByDateDataSetTableAdapters.FindCompanyHolidaysByDateTableAdapter aFindCompanyHolidayByDateTableAdapter;

        public FindCompanyHolidayByDateDataSet FindCompanyHolidayByDate(DateTime datHolidayDate)
        {
            try
            {
                aFindCompanyHolidayByDateDataSet = new FindCompanyHolidayByDateDataSet();
                aFindCompanyHolidayByDateTableAdapter = new FindCompanyHolidayByDateDataSetTableAdapters.FindCompanyHolidaysByDateTableAdapter();
                aFindCompanyHolidayByDateTableAdapter.Fill(aFindCompanyHolidayByDateDataSet.FindCompanyHolidaysByDate, datHolidayDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Company Holiday Class // Find Comapny Holiday By Date " + Ex.Message);
            }

            return aFindCompanyHolidayByDateDataSet;
        }
        public bool InsertCompanyHoliday(string strHoliday, DateTime datHolidayDate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertCompanyHolidayTableAdapter = new InsertCompanyHolidayEntryTableAdapters.QueriesTableAdapter();
                aInsertCompanyHolidayTableAdapter.InsertCompanyHoliday(strHoliday, datHolidayDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Company Holiday Class // Insert Company Holiday " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public CompanyHolidaysDataSet GetCompanyHolidaysInfo()
        {
            try
            {
                aCompanyHolidaysDataSet = new CompanyHolidaysDataSet();
                aCompanyHolidaysTableAdapter = new CompanyHolidaysDataSetTableAdapters.companyholidaysTableAdapter();
                aCompanyHolidaysTableAdapter.Fill(aCompanyHolidaysDataSet.companyholidays);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Company Holiday Class // Get Company Holiday Info " + Ex.Message);
            }

            return aCompanyHolidaysDataSet;
        }
        public void UpdateCompanyHolidayDB(CompanyHolidaysDataSet aCompanyHolidaysDataSet)
        {
            try
            {
                aCompanyHolidaysTableAdapter = new CompanyHolidaysDataSetTableAdapters.companyholidaysTableAdapter();
                aCompanyHolidaysTableAdapter.Update(aCompanyHolidaysDataSet.companyholidays);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Company Holiday Class // Update Company Holiday DB " + Ex.Message);
            }
        }
    }
}
