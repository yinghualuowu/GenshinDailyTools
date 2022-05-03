echo "成功加载index.sh函数文件"

function main_handler () {
    echo "进入main_handler"
    EVENT_DATA=$1
    echo "$EVENT_DATA" 1>&2;
    echo "开始运行GenshinDailyHelper......"
    ./GenshinDailyHelper
    echo "函数结束"
}