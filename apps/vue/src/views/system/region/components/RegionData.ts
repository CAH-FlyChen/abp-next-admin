import { BasicColumn } from '/@/components/Table/src/types/table';
import { useLocalization } from '/@/hooks/abp/useLocalization';
import { Menu } from '/@/api/platform/menus/model';

const { L } = useLocalization(['AppPlatform','System']);

export function getDataColumns(): BasicColumn[] {
  return [
    {
      title: 'code',
      dataIndex: 'code',
      width: 1,
      ifShow: false,
    },
    {
      title: L('DisplayName:Code'),
      dataIndex: 'code',
      align: 'left',
      width: 150,
      resizable: true,
    },
    {
      title: L('DisplayName:Name'),
      dataIndex: 'name',
      align: 'left',
      width: 150,
      resizable: true,
    },
    {
      title: L('DisplayName:RegionTypeCode'),
      dataIndex: 'regionTypeCode',
      align: 'left',
      width: 260,
      resizable: true,
    },
  ];
}
